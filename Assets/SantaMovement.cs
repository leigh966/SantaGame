using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public Transform rudolf;
    public GameObject presentPrefab;
    public Transform sleigh;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        rudolf.position = new Vector3(rudolf.position.x, mouseWorldPos.y+Mathf.Sin(Time.realtimeSinceStartup*2)/2f, rudolf.position.z);
        transform.position = new Vector3(mouseWorldPos.x, transform.position.y, 0f);
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newPres = Instantiate(presentPrefab);
            newPres.transform.position = sleigh.position;
        }
    }
}
