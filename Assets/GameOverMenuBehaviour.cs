using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenuBehaviour : MonoBehaviour
{
    public TextMeshProUGUI bannerText, scoreText;

    public int Score
    {
        set
        {
            scoreText.text = "Your Score: " + value.ToString();
        }
    }


    public string Heading
    {
        set
        {
            bannerText.text = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
