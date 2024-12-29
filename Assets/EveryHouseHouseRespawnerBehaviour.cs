using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryHouseHouseRespawnerBehaviour : RespawnOnTouchBehaviour
{

    public EveryHouseGameBehaviour gameBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void BeforeHouseRespawn(Collision2D collision)
    {
        base.BeforeHouseRespawn(collision);
        var chimney = collision.gameObject.GetComponentInChildren<EveryHouseChimneyBehaviour>();
        if (!chimney.HasScored) gameBehaviour.EndGame();
        chimney.HouseReset();
        
    }
}
