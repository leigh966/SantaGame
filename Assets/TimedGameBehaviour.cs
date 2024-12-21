using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(SantaScoreSystem))]
public class TimedGameBehaviour : MonoBehaviour
{
    public float gameLengthInSeconds;
    public BasicAutoScroll autoScroll;
    public SantaMovement movementScript;
    public GameObject gameOverMenu;
    public ScoreSystem scoreSystem;
    public TMPro.TextMeshProUGUI timerOutput;

    private float currentTime;
    private bool done = false;
    public void EndGame()
    {
        scoreSystem.enabled = false;
        autoScroll.enabled = false;
        movementScript.enabled = false;
        gameOverMenu.SetActive(true);
        var lbInterface = new TimedLeaderboardInterface();
        StartCoroutine(lbInterface.Post());
        done = true;
    }


    void DisplayTime()
    {
        string secondsString = ((int)(currentTime % 60f)).ToString();
        if (secondsString.Length < 2)
        {
            secondsString = "0" + secondsString;
        }
        timerOutput.text = ((int)(currentTime/60f)).ToString()+":"+secondsString;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = gameLengthInSeconds;
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
            EndGame();
            return;
        }
        DisplayTime();
    }
}
