using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnTouchBehaviour : MonoBehaviour
{

    public LayerMask layersToApply;
    public Transform spawnPoint;

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
        if ((layersToApply & (1 << collision.gameObject.layer)) != 0)
        {
            collision.transform.position = spawnPoint.position;
        }
    }
}
