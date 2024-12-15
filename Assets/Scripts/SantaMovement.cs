using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public Transform rudolf;
    public List<GameObject> presentPrefabs;
    public Transform sleigh;
    public float parcelCooldown;

    private bool canDrop;


    // Start is called before the first frame update
    void Start()
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

    void DropPresent()
    {
        GameObject newPres = Instantiate(ChooseRandomPresent());
        newPres.transform.position = sleigh.position;
        canDrop = false;
        Invoke("EnableDrop", parcelCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        rudolf.position = new Vector3(rudolf.position.x, mouseWorldPos.y+Mathf.Sin(Time.realtimeSinceStartup*2)/2f, rudolf.position.z);
        transform.position = new Vector3(mouseWorldPos.x, transform.position.y, 0f);
        if(canDrop && Input.GetMouseButtonDown(0))
        {
            DropPresent();
        }
    }
}
