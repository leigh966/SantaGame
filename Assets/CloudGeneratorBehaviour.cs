using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class CloudGeneratorBehaviour : MonoBehaviour
{
    public float minHeight, maxHeight;
    public float minTimeBetween, maxTimeBetween;

    private ParticleSystem generator;


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
    }
}
