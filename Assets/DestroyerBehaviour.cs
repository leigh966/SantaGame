using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class DestroyerBehaviour : MonoBehaviour
{
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void BeforeDestroyingObject()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((mask & (1 << collision.gameObject.layer)) != 0)
        {
            BeforeDestroyingObject();
            Destroy(collision.gameObject);
        }
    }
}
