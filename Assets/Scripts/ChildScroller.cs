using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScroller : ScrollingBehaviour
{

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in transform)
        {
            child.Translate(Vector3.left*scrollSpeed*Time.deltaTime, Space.World);
        }
    }
}
