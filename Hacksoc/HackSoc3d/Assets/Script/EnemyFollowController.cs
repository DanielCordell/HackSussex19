using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowController : MonoBehaviour
{
    [Header("Target")]
    private GameObject player;

    [HideInInspector]
    public float speed;

    void Start()
    {
        player = GameObject.Find("Player");
        speed = gameObject.GetComponent<EnemyStats>().startingSpeed;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            HitPlayer();
        }
    }

    private void HitPlayer()
    {
        player.GetComponent<PlayerStats>().takeDamage();
            
    }


}
