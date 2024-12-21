using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class TimedLeaderboardInterface : LeaderboardInterface
{

    public override List<LeaderboardEntry> Get()
    {
        throw new System.NotImplementedException();
    }




    public override IEnumerator Post()
    {
        Debug.Log("I ran!");
        string name = PlayerPrefs.GetString("name");
        string score = PlayerPrefs.GetInt("timedScore").ToString();
        string checksum = sha256(name + score + secret);
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>
        {
            new MultipartFormDataSection("name", name),
            new MultipartFormDataSection("score", score),
            new MultipartFormDataSection("checksum", checksum)
        };

        using (UnityWebRequest www = UnityWebRequest.Post(host + "/timed", formData))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                //GetComponent<PopupSpawner>().Create(400, 400, "Failed to upload results. Please try again later by loading this save");
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
