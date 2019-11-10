using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Win : MonoBehaviour
{
    public GameObject gameOver;
    public Text Text;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Text.GetComponent<Text>().text = "LEVEL COMPLETE";
            gameOver.GetComponent<GameOver>().GameOverMethod(); 
        }
    }
}
