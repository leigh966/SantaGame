using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameInputBehaviour : MonoBehaviour
{
    public TextMeshProUGUI input;
    public GameObject namePopup;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("name"))
        {
            namePopup.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Clear Prefs")]
    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnSubmit()
    {
        PlayerPrefs.SetString("name", input.text);
    }
}
