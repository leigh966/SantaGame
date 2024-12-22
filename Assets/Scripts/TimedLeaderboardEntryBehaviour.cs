using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimedLeaderboardEntryBehaviour : LeaderboardEntryBehaviour
{
    public TextMeshProUGUI scoreText;


    public string Score
    {
        get
        {
            return scoreText.text;
        }
        set
        {
            scoreText.text = value;
        }
    }

}
