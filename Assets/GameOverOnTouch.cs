using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTouch : MonoBehaviour
{
    public GameOverPassthrough passthrough;
    public LayerMask affectedLayers;
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
        if(LayerTools.LayerInMask(collision.gameObject.layer, affectedLayers))
        {
            collision.gameObject.SetActive(false);


            passthrough.EndGame();
        }
        
    }

}
