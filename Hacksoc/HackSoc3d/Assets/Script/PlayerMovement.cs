using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Params")]
    public float StartSpeed = 5f;


    [HideInInspector]
    public float speed;

    void Start()
    {
        speed = StartSpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))  // If the player is pressing the "d" key
        {

            // Add a force to the right
            velocity += Vector3.left * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            velocity += Vector3.right * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))  // If the player is pressing the "d" key
        {
            // Add a force to the right
            velocity += Vector3.forward * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            velocity += Vector3.back * Time.deltaTime;
        }

        GetComponent<Rigidbody>().velocity = velocity.normalized * speed;

    }
}
