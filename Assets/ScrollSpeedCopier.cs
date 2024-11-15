using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpeedCopier : MonoBehaviour
{
    public ScrollingBehaviour source;
    public List<ScrollingBehaviour> destinations;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var sb in destinations)
        {
            sb.scrollSpeed = source.scrollSpeed;
        }
    }
}
