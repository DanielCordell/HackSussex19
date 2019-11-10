using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameAdjuster : MonoBehaviour
{
    public List<string> commands = new List<string>();
    public Text display;
    public Dictionary<string, int> commandCount = new Dictionary<string, int>();

    public List<string> names = new List<string>();

    public List<string> phrases = new List<string>();

    public GameObject ExplosionEffect;


    public float timeBetweenUpdates;
    private float currentTime;
    private float currentTimescale;
    private string currentAction;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        Reset();
    }

    void Reset()
    {
        commandCount["slow"] = 0;
        commandCount["fast"] = 0;
        commandCount["kill"] = 0;
        commandCount["bighead"] = 0;
        currentTime = timeBetweenUpdates;
        currentTimescale = 1.0f;
    }

    public void AddCommands(List<string> commands)
    {
        foreach (string command in commands)
        {
            if (command == "slow" || command == "fast" || command == "kill" || command == "bighead") 
                commandCount[command]++;
            else if (command.Contains(" "))
            {
                string cmdStmt = command.Substring(0, command.IndexOf(" "));
                string cmdEnd = command.Substring(command.IndexOf(" "));
                if (cmdStmt == "name")
                {
                    this.names.Add(cmdEnd);
                }

                if (cmdStmt == "phrase")
                {
                    this.phrases.Add(cmdEnd);
                }
            }
        }
    }

    void Update()
    {
        if (currentTime <= 0)
        {
            // Revert previous thing if it was a timecale:

            if (currentAction == "slow" || currentAction == "fast")
            {
                currentTimescale = 1.0f;
                Time.timeScale = 1.0f;
            }

            if (currentAction == "bighead")
            {
                player.transform.localScale -= new Vector3(2, 2, 2);
            }


            string maxCommand = "";
            int maxCount = 0;
            foreach (var item in commandCount)
            {
                if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                    maxCommand = item.Key;
                }
            }

            if (maxCount != 0)
            {
                currentAction = maxCommand;
                performAction(currentAction);
            }
            Reset();
        }
        else
        {
            currentTime -= Time.deltaTime * (1 / currentTimescale);
        }

        display.text = ("slow: " + commandCount["slow"] + "\n" +
            "fast: " + commandCount["fast"] + "\n" +
             "Kill: " + commandCount["kill"] +"\t"+ currentTime.ToString() +
              "powerup: " + commandCount["powerup"] + "\n" +
               "bighead: " + commandCount["bighead"] +"\n"+
               "enemy: " + commandCount["enemy"]);
    }

    void performAction(string action)
    {
        switch (action)
        {
            case "slow":
                currentTimescale = 0.3f;
                break;
            case "fast":
                currentTimescale = 1.5f;
                break;
            case "kill":
                Debug.Log("KILL");
                var found = FindObjectsOfType<EnemyStats>();
                if (found.Length == 0) return;
                int numberToKill = Random.Range(1, found.Length > 3 ? 3 : found.Length);
                List<int> objs = new List<int>();
                while (objs.Count < numberToKill)
                {
                    int randIndex = Random.Range(0, found.Length);
                    if (objs.Contains(randIndex)) continue;
                    objs.Add(randIndex);
                }

                foreach (int index in objs)
                {
                    GameObject effectObject = (GameObject)Instantiate(ExplosionEffect, found[index].transform.position, Quaternion.Euler(-90f,0f, 0f));
                    found[index].GetComponent<EnemyStats>().Die();
                    Destroy(effectObject, 2f);
                }

                break;
            case "bighead":
                Debug.Log("BIGHEAD");
                player.transform.localScale += new Vector3(2, 2, 2);
                break;
        }
        Time.timeScale = currentTimescale;
    }
}
