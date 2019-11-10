using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class TwilioReceiver : MonoBehaviour
{
    public string twilioReceiver;
    private GameAdjuster gameAdjuster;

    private float timeTillNext = 0;
    public float timeBetweenUpdates;

    void Start()
    {
        gameAdjuster = gameObject.GetComponent<GameAdjuster>();
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(twilioReceiver + "/receive");
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else
        {
            string text = www.downloadHandler.text;
            if (String.Compare(text, "{\"commands\":[]}") == 0) yield break;
            Debug.Log("Received: " + text);
            Data data = JsonUtility.FromJson<Data>(text);
            gameAdjuster.AddCommands(data.commands);
        }
    }

    void FixedUpdate()
    {
        if(timeTillNext < 0)
        {
            timeTillNext = timeBetweenUpdates;
            StartCoroutine(GetText());
        }
        else
        {
            timeTillNext -= Time.deltaTime;
        }
    }
}

[System.Serializable]
public class Data
{
    public List<string> commands;
}
