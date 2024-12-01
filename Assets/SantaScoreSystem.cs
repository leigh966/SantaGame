using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaScoreSystem : ScoreSystem
{
    public Animator santa;
    public override void IncrementScore()
    {
        base.IncrementScore();

        santa.SetTrigger("Goal");
    }

}
