using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PresentBehaviour : ScrollingBehaviour
{
    public float leftwardForce;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right*scrollSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }


}
