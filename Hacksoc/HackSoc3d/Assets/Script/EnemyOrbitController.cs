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
    public float timeBetweenBullet;
    private float currentTimeToBullet;

    public GameObject bullet;

    public Material material;

    void Start()
    {
        speed = gameObject.GetComponent<EnemyStats>().startingSpeed;
        player = GameObject.Find("Player");
        currentTimeToBullet = timeBetweenBullet;
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
            transform.LookAt(player.transform.position);
            currentTimeToBullet -= Time.deltaTime;
            if (currentTimeToBullet <= 0)
            {        
                currentTimeToBullet = timeBetweenBullet;
                GameObject newBullet = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.transform.LookAt(player.transform.position);
                newBullet.GetComponent<EnemyBullet>().setStats(transform.forward, 5, 30, material);
            }
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
