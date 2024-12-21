using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class SpeedChangeAreaBehaviour : MonoBehaviour
{
    public float speedDelta;
    public float maxSpeed, minSpeed;
    public ScrollingBehaviour scroller;
    public LayerMask layersToDetect;


    private int colliding;
    

    // Start is called before the first frame update
    void Start()
    {
        colliding = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding <= 0) return;
        scroller.scrollSpeed = Mathf.Clamp(scroller.scrollSpeed + speedDelta * Time.deltaTime, minSpeed, maxSpeed);   
    }

    private bool CollidingWithTargets(int layer)
    {
        return (layersToDetect & (1 << layer)) != 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollidingWithTargets(collision.gameObject.layer))
        {
            colliding++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (CollidingWithTargets(collision.gameObject.layer))
        {
            colliding--;
        }
    }
}
