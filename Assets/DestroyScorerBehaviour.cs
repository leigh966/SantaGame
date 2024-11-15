using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScorerBehaviour : MonoBehaviour
{
    public LayerMask layerMask;
    public ScoreSystem scorer;
    
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
        if ((layerMask & (1 << collision.gameObject.layer)) != 0)
        {
            Destroy(collision.gameObject);
            scorer.IncrementScore();
        }
    }

}
