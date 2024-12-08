using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWhileCollidingBehaviour : MonoBehaviour
{

    public GameObject toEnable;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        toEnable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(LayerTools.LayerInMask(collision.gameObject.layer, mask))
        {
            toEnable.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
 
    }

}
