using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class CloudGeneratorBehaviour : MonoBehaviour
{
    public float minHeight, maxHeight;
    public float minTimeBetween, maxTimeBetween;
    public SpriteRenderer filter;

    private ParticleSystem generator;
    public float filterFadeTime, filterMaxOpacity, filterOpacityStep;
    float filterOpacity;
    public float windCooldown;
    float windCoolCounter = 0f;

    void QueueNextCloud()
    {
        Invoke("GenerateCloud", Random.Range(minTimeBetween, maxTimeBetween));
    }
    void RandomizeHeight()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z);
    }

    void GenerateCloud()
    {
        RandomizeHeight();
        generator.Play();
        QueueNextCloud();
    }


    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponent<ParticleSystem>();
        QueueNextCloud();
    }



    // Update is called once per frame
    void Update()
    {
        var col = filter.material.color;
        col.a = filterOpacity;
        filter.material.color = col;
        windCoolCounter -= Time.deltaTime;
    }

    void StepDownFilterOpacity()
    {
        filterOpacity -= filterOpacityStep;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (filterOpacity < filterMaxOpacity && other.layer == 7)
        {
            filterOpacity += filterOpacityStep;
            Invoke("StepDownFilterOpacity", filterFadeTime);
            if (windCoolCounter < 0f)
            {
                GetComponent<AudioSource>().Play();
                windCoolCounter = windCooldown;
            }
        }
    }

}
