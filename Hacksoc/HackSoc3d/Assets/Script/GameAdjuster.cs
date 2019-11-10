using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAdjuster : MonoBehaviour
{
    public List<string> commands = new List<string>();

    public Dictionary<string, int> commandCount = new Dictionary<string, int>();

    public List<string> names = new List<string>();

    public List<string> phrases = new List<string>();

    public float timeBetweenUpdates;

    void Start()
    {
        Reset();
    }

    void Reset()
    {
        commandCount["slow"] = 0;
        commandCount["fast"] = 0;
        commandCount["kill"] = 0;
        commandCount["enemy"] = 0;
        commandCount["powerup"] = 0;
    }

    public void AddCommands(List<string> commands)
    {
        foreach (string command in commands)
        {
            if (command == "slow" || command == "fast" || command == "powerup" || command == "kill" || command == "enemy") 
                commandCount[command]++;
            else
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

    void FixedUpdate()
    {
        if (commands.Count == 0) return;
        foreach (string str in commands)
        {
            Debug.Log(str);
        }
    }
}
