using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PresentBehaviour : ScrollingBehaviour
{
    public float leftwardForce;
    private Rigidbody2D rb;
    private bool applyForce = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!applyForce)
        {
            transform.Translate(Vector2.left*Time.deltaTime*scrollSpeed);
        }
    }

    private void FixedUpdate()
    {
        float forceMagnitude = leftwardForce * Convert.ToInt32(applyForce);
        Debug.Log(forceMagnitude);
        rb.AddForce(Vector2.left*forceMagnitude);
    }

    private void CancelLeftDrift()
    {
        applyForce = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CancelLeftDrift();
    }
}
