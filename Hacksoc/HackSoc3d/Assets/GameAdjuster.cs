using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAdjuster : MonoBehaviour
{
    public List<string> commands;

    public void AddCommands(List<string> commands)
    {
        this.commands.AddRange(commands);
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
