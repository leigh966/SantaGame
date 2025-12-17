using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SantaScoreSystem : ScoreSystem
{
    public Animator santa;

    public string PrefToSet;

    public List<AudioClip> beepSounds;

    public int Score
    {
        get
        {
            return score;
        }
    }

    protected override void Start()
    {
        base.Start();
        PlayerPrefs.SetInt(PrefToSet, score);
    }


    private AudioClip RandomBeep()
    {
        int index = Random.Range(0, beepSounds.Count);
        return beepSounds[index];
    }

    public override void IncrementScore()
    {
        base.IncrementScore();

        santa.SetTrigger("Goal");
        GetComponent<AudioSource>().PlayOneShot(RandomBeep());

        PlayerPrefs.SetInt(PrefToSet, score);

    }

}
