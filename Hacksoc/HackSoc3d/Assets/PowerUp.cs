using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject powerUp;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hello");
        if(collision.gameObject.tag == "Player")
        {

           collision.gameObject.GetComponent<PlayerStats>().PowerUpPickUp(powerUp);
            Destroy(gameObject);
        }
    }





}
