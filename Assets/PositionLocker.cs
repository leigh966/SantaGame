using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PositionLocker : MonoBehaviour
{

    public bool lockX, lockY, lockZ;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        float x = lockX ? startPos.x : transform.position.x;
        float y = lockY ? startPos.y : transform.position.y;
        float z = lockZ ? startPos.z : transform.position.z;
        transform.position = new Vector3(x,y,z);
    }
}
