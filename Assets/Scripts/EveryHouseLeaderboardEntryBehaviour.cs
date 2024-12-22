using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

    public class EveryHouseLeaderboardEntryBehaviour : LeaderboardEntryBehaviour
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

    public TextMeshProUGUI timeText;


    public string Time
    {
        get
        {
            return timeText.text;
        }
        set
        {
            timeText.text = value;
        }
    }
}

