using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFollowLink : MonoBehaviour
{
    public Transform target;
    public float acceptableDelta;
    public float baseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float heightDelta = target.position.y - transform.position.y;
        float speed = Mathf.Abs(heightDelta) < acceptableDelta ? 0f : heightDelta * baseSpeed;
        transform.Translate(0f, speed * Time.deltaTime, 0f, Space.World);
    }
}
