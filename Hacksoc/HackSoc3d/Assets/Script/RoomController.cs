using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject spawners;
    private ArrayList roomEntities;
    public GameObject databaseOBJ;

    enum RoomType
    {
        WEAPON = 0,
        ENEMY = 1,
        MIXED = 2,
        BOSS = 3
    };

    private RoomType roomtype;
    private void Start()
    {
        roomEntities = new ArrayList();
        roomtype = (RoomType)Random.Range(0, 4);

        foreach (Transform spawner in spawners.GetComponentInChildren<Transform>())
        {
            GameObject _entity = pickEntity(spawner);
            roomEntities.Add(_entity);
        }
    }




    GameObject pickEntity(Transform spawner)
    {
        switch (Random.Range(0, 2))
        {
            case 1:
                return (GameObject)Instantiate(databaseOBJ.GetComponent<EntityDatabase>().getRandomPowerUp(), spawner);
            default:
                return (GameObject)Instantiate(databaseOBJ.GetComponent<EntityDatabase>().getRandomEnemy(), spawner);

        }
    }


}


