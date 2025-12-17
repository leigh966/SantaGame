using UnityEngine;
using UnityEngine.XR;

public class GameBehaviour : MonoBehaviour
{
    public BasicAutoScroll autoScroll;
    public SantaMovement movementScript;
    public GameObject gameOverMenu;
    public ScoreSystem scoreSystem;
    public TMPro.TextMeshProUGUI timerOutput;

    protected bool done;

    private void Start()
    {
       
    }

    public virtual void EndGame(LeaderboardInterface lbInterface)
    {
        var music = GameObject.FindGameObjectWithTag("BackgroundMusic");
        if (music != null)
        {
            music.GetComponent<AudioSource>().pitch = 0.85f;
        }
        else
        {
            Debug.LogError("No background music found");
        }
        scoreSystem.enabled = false;
        autoScroll.enabled = false;
        movementScript.enabled = false;
        gameOverMenu.SetActive(true);
        var gameOverMenuBehaviour = gameOverMenu.GetComponent<GameOverMenuBehaviour>();
        gameOverMenuBehaviour.Score = scoreSystem.GetScore();
        StartCoroutine(lbInterface.Post());
        done = true;
        
    }


    public string ToDisplayableTime(float timeInSeconds)
    {
        string secondsString = ((int)(timeInSeconds % 60f)).ToString();
        if (secondsString.Length < 2)
        {
            secondsString = "0" + secondsString;
        }
        return ((int)(timeInSeconds / 60f)).ToString() + ":" + secondsString; ;
    }

    public void DisplayTime(float timeInSeconds)
    {
        timerOutput.text = ToDisplayableTime(timeInSeconds);
    }
}