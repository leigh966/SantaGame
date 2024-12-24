using UnityEngine;
using System.Collections.Generic;


    public class DemoSantaMovement : SantaMovement
    {
    public List<Vector3> startPositions;
    public List<Vector3> endPositions;
    public List<float> times;

    private int currentPathIndex;
    private Vector3 travelPerSecond;
    private float currentTime;

    void FlipXScale()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void DoNextPath()
    {
        currentPathIndex = (currentPathIndex + 1)%startPositions.Count;
        transform.position = startPositions[currentPathIndex];
        travelPerSecond = (endPositions[currentPathIndex] - startPositions[currentPathIndex]) / times[currentPathIndex];
        currentTime = 0;
        if(travelPerSecond.x < 0 && transform.localScale.x > 0 || travelPerSecond.x > 0 && transform.localScale.x < 0)
        {
            FlipXScale();
        }
    }

    protected override void Start()
    {
        base.Start();
        Debug.Assert(startPositions.Count == endPositions.Count);
        currentPathIndex = -1;
        DoNextPath();
    }

    protected override void Update()
    {
        transform.Translate(travelPerSecond * Time.deltaTime, Space.World);
        currentTime += Time.deltaTime;
        if( currentTime > times[currentPathIndex]) {
        DoNextPath() ;
            

        }
        Vector3 rudolfPos = rudolf.position;
        rudolfPos.y = (startPositions[currentPathIndex].y + Mathf.Sin(currentTime * 3.6f));
        rudolf.position = rudolfPos;
    }
}

