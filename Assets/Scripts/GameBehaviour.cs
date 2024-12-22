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
    public virtual void EndGame(LeaderboardInterface lbInterface)
    {
        scoreSystem.enabled = false;
        autoScroll.enabled = false;
        movementScript.enabled = false;
        gameOverMenu.SetActive(true);
        StartCoroutine(lbInterface.Post());
        done = true;
    }

    public void DisplayTime(float timeInSeconds)
    {
        string secondsString = ((int)(timeInSeconds % 60f)).ToString();
        if (secondsString.Length < 2)
        {
            secondsString = "0" + secondsString;
        }
        timerOutput.text = ((int)(timeInSeconds / 60f)).ToString() + ":" + secondsString;
    }
}