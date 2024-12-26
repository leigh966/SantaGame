using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(SantaScoreSystem))]
public class TimedGameBehaviour : GameBehaviour
{
    public float gameLengthInSeconds;
    private float currentTime;
    public TMPro.TextMeshProUGUI gameOverScoreOutput;
    private SantaScoreSystem scoreSystem;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = gameLengthInSeconds;
        scoreSystem = GetComponent<SantaScoreSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            return;
        }
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            EndGame(new TimedLeaderboardInterface());
            return;
        }
        gameOverScoreOutput.text = "Your Score: "+scoreSystem.Score.ToString();
        DisplayTime(currentTime);
    }
}
