using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void EndGame()
    {
        scoreSystem.enabled = false;
        autoScroll.enabled = false;
        movementScript.enabled = false;
        gameOverMenu.SetActive(true);
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
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            EndGame();
            return;
        }
        DisplayTime();
    }
}
