using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBehaviour : MonoBehaviour
{
    public float leftwardForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left*leftwardForce);
    }
}
