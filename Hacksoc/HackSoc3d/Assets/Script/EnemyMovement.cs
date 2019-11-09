using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [HideInInspector]
    public float speed;

    void Start()
    {
        speed = gameObject.GetComponent<EnemyStats>().startingSpeed;

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

