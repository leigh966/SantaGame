using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimedLeaderboardEntryBehaviour : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    public string Name
    {
        get
        {
            return nameText.text;
        }
        set { 
            nameText.text = value;
        }
    }

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
