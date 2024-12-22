using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryHouseGameBehaviour : GameBehaviour
{
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    public override void EndGame(LeaderboardInterface lbInterface)
    {
        PlayerPrefs.SetString("everyHouseTime", ToDisplayableTime(currentTime));
        base.EndGame(lbInterface);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(done)
        {
            return;
        }
        currentTime += Time.deltaTime;
        DisplayTime(currentTime);
    }
}
