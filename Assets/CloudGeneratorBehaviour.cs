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
    public float filterMaxTtl, filterMaxOpacity;
    private float filterTtl = 0;


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
        filterTtl -= Time.deltaTime;
        var col = filter.material.color;
        col.a = filterTtl / filterMaxTtl * filterMaxOpacity;
        filter.material.color = col;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == 7)
        {
            filterTtl = filterMaxTtl;
        }
    }

}
