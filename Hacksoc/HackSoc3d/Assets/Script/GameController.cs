using System;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public GameObject oneDoor;
    public GameObject twoDoors;
    public GameObject threeDoors;
    public GameObject fourDoors;
    public GameObject End;

    private System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        for (int i = 1; i <= 10; i++)
        {
            if(i == 10)
            {
                Instantiate(End, new Vector3(0, -4, 750), Quaternion.Euler(0, 180, 0));
                break;
            }
            int num = rand.Next(2, 5);
            if(num == 2)
            {
                Instantiate(twoDoors, new Vector3(0, -4f, i * 75), Quaternion.identity);
                GameObject spawnPoint;
            }
            else if (num == 3)
            {
                GameObject room = Instantiate(threeDoors, new Vector3(0, -4f, i * 75), Quaternion.identity);
                addSideRoom(3, room);
            }
            else
            {
                GameObject room = Instantiate(fourDoors, new Vector3(0, -4f, i * 75), Quaternion.identity);
                addSideRoom(4, room);
            }
        }
    }

    void addSideRoom(int numOfDoors, GameObject room)
    {
        if(numOfDoors == 3)
        {
            Instantiate(oneDoor, new Vector3(room.transform.position.x - 75, -4, room.transform.position.z), Quaternion.Euler(0, 90, 0));
        }
        else
        {
            Instantiate(oneDoor, new Vector3(room.transform.position.x - 75, -4, room.transform.position.z), Quaternion.Euler(0, 90, 0));
            Instantiate(oneDoor, new Vector3(room.transform.position.x + 75, -4, room.transform.position.z), Quaternion.Euler(0, 270, 0));
        }
    }
}