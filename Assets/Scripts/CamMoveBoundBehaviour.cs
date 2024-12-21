using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveBoundBehaviour : MonoBehaviour
{
    public Collider2D toDetect;
    public float minOrMaxX, minOrMaxY;
    public Vector3 movement;

    bool minX, minY;

    Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        minX = movement.x < 0;
        minY = movement.y < 0;
    }

    bool shouldMove(float pos, bool min, float minOrMax)
    {
        return !(pos < minOrMax && min || pos > minOrMax && !min);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider==toDetect)
        {
            Vector3 delta = new Vector3(shouldMove(camTransform.position.x, minX, minOrMaxX) ? movement.x : 0f, shouldMove(camTransform.position.y, minY, minOrMaxY) ? movement.y : 0f, 0f);
            camTransform.position = camTransform.position + delta*Time.deltaTime;
        }
    }

}
