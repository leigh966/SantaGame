using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeToucher : MonoBehaviour
{

    public LayerMask layerMask;

    public float minimumAbsoluteScaleX;
    public float maximumAbsoluteScaleX;
    public bool leftRightFlip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((layerMask & (1 << collision.gameObject.layer)) != 0)
        {
            float xScale = Random.Range(Mathf.Abs(minimumAbsoluteScaleX), Mathf.Abs(maximumAbsoluteScaleX));
            bool shouldFlip = Random.Range(0, 2) == 1 ? true : false;
            if (shouldFlip) xScale *= -1;
            Vector3 currentScale = collision.transform.localScale;
            collision.transform.localScale = new Vector3(xScale, currentScale.y, currentScale.z);
        }
    }
}
