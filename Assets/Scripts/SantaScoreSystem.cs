using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaScoreSystem : ScoreSystem
{
    public Animator santa;

    public string PrefToSet;

    protected override void Start()
    {
        base.Start();
        PlayerPrefs.SetInt(PrefToSet, score);
    }

    public override void IncrementScore()
    {
        base.IncrementScore();

        santa.SetTrigger("Goal");

        PlayerPrefs.SetInt(PrefToSet, score);

    }

}
