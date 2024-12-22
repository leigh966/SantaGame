using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardEntryBehaviour : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI posText;

    public string Name
    {
        get
        {
            return nameText.text;
        }
        set
        {
            nameText.text = value;
        }
    }

    public string Pos
    {
        get
        {
            return posText.text;
        }
        set
        {
            posText.text = value;
        }
    }
}
