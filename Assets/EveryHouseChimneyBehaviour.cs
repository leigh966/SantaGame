using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EveryHouseChimneyBehaviour : DestroyScorerBehaviour
{
    public List<SpriteRenderer> filters;
    public Color preScore, postScore;
    public float opacity;
    private float scoredAt;

    public bool HasScored
    {
        get {
            return scored;
        }
    }

    bool scored;

    void SetFilterColor(Color color)
    {
        scoredAt = 1000f;
        Color paintColor = color;
        //color.a = opacity;
        foreach(var filter in filters)
        {
            filter.color = paintColor;
        }
    }

    public void HouseReset()
    {
        SetFilterColor(preScore);
        scored = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        HouseReset();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoredAt < transform.position.x)
        {
            HouseReset();
        }
    }

    protected override void BeforeDestroyingObject()
    {
        base.BeforeDestroyingObject();
        scoredAt = transform.position.x;
        SetFilterColor(postScore);
        scored = true;
    }
}
