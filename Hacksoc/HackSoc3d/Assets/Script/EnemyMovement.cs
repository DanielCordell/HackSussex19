using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Params")]
    public float StartSpeed = 500f;
    public Transform player;

    [HideInInspector]
    public float speed;

    void Start()
    {
        speed = StartSpeed;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitPlayer();
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }



    private void HitPlayer()
    {
        Debug.Log("PlayerHit");
    }
}

