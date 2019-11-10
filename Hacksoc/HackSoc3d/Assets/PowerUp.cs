using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject powerUp;

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {

           other.gameObject.GetComponent<PlayerStats>().PowerUpPickUp(powerUp);
           Destroy(gameObject);
        }
    }





}
