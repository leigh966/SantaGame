using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    protected int score;
    public TMPro.TextMeshProUGUI outputText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(outputText)
        {
            outputText.text = score.ToString();
        }
    }

    public virtual void IncrementScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }
}
