using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BasicAutoScroll))]
public class ScrollAccelerator : MonoBehaviour
{
    private BasicAutoScroll autoScroll;

    public float increasePerSecond;

    // Start is called before the first frame update
    void Start()
    {
        autoScroll = GetComponent<BasicAutoScroll>();
    }

    // Update is called once per frame
    void Update()
    {
        autoScroll.scrollSpeed += increasePerSecond * Time.deltaTime;
    }
}
