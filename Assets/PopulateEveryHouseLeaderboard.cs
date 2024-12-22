using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PopulateEveryHouseLeaderboard : MonoBehaviour
{
    public GameObject leaderboardEntryPrefab;
    public Transform tableContent;
    public RectTransform scrollView;
    public float rowHeight;

    bool GenerateRows(UnityWebRequest www)
    {

        var leaderboard = JsonUtility.FromJson<EveryHouseLeaderboard>(www.downloadHandler.text);
        scrollView.sizeDelta = new Vector2(0, rowHeight * (leaderboard.entries.Count + 1));
        for (int i = 0; i < leaderboard.entries.Count; i++)
        {
            var entry = leaderboard.entries[i];
            var row = Instantiate(leaderboardEntryPrefab, tableContent);
            var rowBehaviour = row.GetComponent<EveryHouseLeaderboardEntryBehaviour>();
            rowBehaviour.Pos = (i + 1).ToString();
            rowBehaviour.Name = entry.name;
            rowBehaviour.Score = entry.score;
            rowBehaviour.Time = entry.time;
        }
        return true;
    }


    public void Populate()
    {
        StartCoroutine(new EveryHouseLeaderboardInterface().Get(GenerateRows));
    }

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
