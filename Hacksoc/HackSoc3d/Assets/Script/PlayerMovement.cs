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
    void Update()
    {
        Debug.Log(Time.deltaTime);
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))  // If the player is pressing the "d" key
        {

            // Add a force to the right
            velocity += Vector3.left * speed * Time.deltaTime * 1000;
        }

        if (Input.GetKey(KeyCode.D))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            velocity += Vector3.right * speed * Time.deltaTime * 1000;
        }

        if (Input.GetKey(KeyCode.W))  // If the player is pressing the "d" key
        {
            // Add a force to the right
            velocity += Vector3.forward * speed * Time.deltaTime * 1000;
        }

        if (Input.GetKey(KeyCode.S))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            velocity += Vector3.back * speed * Time.deltaTime * 1000;
        }

        GetComponent<Rigidbody>().velocity = velocity;

    }
}
