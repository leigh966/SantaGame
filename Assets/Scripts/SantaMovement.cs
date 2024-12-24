using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public Transform rudolf;
    public List<GameObject> presentPrefabs;
    public Transform sleigh;
    public float parcelCooldown;

    private bool canDrop;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        canDrop = true;
    }

    private GameObject ChooseRandomPresent()
    {
        int index = Random.Range(0, presentPrefabs.Count);
        return presentPrefabs[index];
    }

    private void EnableDrop()
    {
        canDrop = true;
    }

    private float RandomAngle()
    {
        return Random.Range(0f, 360f);
    }

    public void DropPresent()
    {
        GameObject newPres = Instantiate(ChooseRandomPresent());
        newPres.transform.position = sleigh.position;
        newPres.transform.eulerAngles = new Vector3(0f,0f,RandomAngle());
        canDrop = false;
        Invoke("EnableDrop", parcelCooldown);
    }

    protected Vector3 GetMousePosition()
    {
        return new Vector3(Mathf.Clamp(Input.mousePosition.x, 0f, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0f, Screen.height), Input.mousePosition.z);
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(GetMousePosition(), Camera.MonoOrStereoscopicEye.Mono);
        rudolf.position = new Vector3(rudolf.position.x, mouseWorldPos.y+Mathf.Sin(Time.realtimeSinceStartup*2)/2f, rudolf.position.z);
        transform.position = new Vector3(mouseWorldPos.x, transform.position.y, 0f);
        if(canDrop && Input.GetMouseButtonDown(0))
        {
            DropPresent();
        }
    }
}
