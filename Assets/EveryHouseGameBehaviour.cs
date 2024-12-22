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
        base.EndGame(lbInterface);
        PlayerPrefs.SetFloat("everyHouseTime", currentTime);
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
