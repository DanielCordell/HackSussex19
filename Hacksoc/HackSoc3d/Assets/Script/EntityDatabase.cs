using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EntityDatabase :MonoBehaviour
{
    public  GameObject[] minorEnemys;
    public  GameObject[] Bosses;
    public  GameObject[] powerUps;

    public GameObject getRandomEnemy()
    {
        return minorEnemys[Random.Range(0, minorEnemys.Length)];
    }

    public GameObject getRandomBoss()
    {
        return Bosses[Random.Range(0, Bosses.Length)];
    }
    public GameObject getRandomPowerUp()
    {
        return powerUps[Random.Range(0, powerUps.Length)];
    }

}
