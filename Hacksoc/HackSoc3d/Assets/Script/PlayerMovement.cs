using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Params")]
    public float StartSpeed = 500f;


    [HideInInspector]
    public float speed;

     void Start()
    {
        speed = StartSpeed;
        
    }
    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.A))  // If the player is pressing the "d" key
        {

            // Add a force to the right
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))  // If the player is pressing the "d" key
        {
            // Add a force to the right
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

    }
}
