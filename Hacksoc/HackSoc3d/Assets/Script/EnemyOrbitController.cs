using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrbitController : MonoBehaviour
{
    [Header("Target")]
    private GameObject player;

    [HideInInspector]
    public float speed;

    public float orbitDistanceMax;
    public float orbitDistanceMin;

    void Start()
    {
        speed = gameObject.GetComponent<EnemyStats>().startingSpeed;
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude > orbitDistanceMax)
        {
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        else if (dir.magnitude < orbitDistanceMin)
        {
            transform.Translate(-dir.normalized * distanceThisFrame, Space.World);
        }
        else
        {
            transform.RotateAround(player.transform.position, Vector3.up, distanceThisFrame/dir.magnitude * 100);
        }
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
