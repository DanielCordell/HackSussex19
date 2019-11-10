using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float radius;
    private float projectileSpeed;
    private Material material;

    Vector3 direction;
    public GameObject player;

    public GameObject ImpactEffect;

    void Start()
    {
        player = GameObject.Find("Player");
    } 

    public void setStats(Vector3 _direction, float _radius, float _projectileSpeed, Material _material)
    {
        direction = _direction;
        radius = _radius;
        projectileSpeed = _projectileSpeed;
        material = _material;
        GetComponent<Renderer>().material = material;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = direction * Time.deltaTime;

        GetComponent<Rigidbody>().velocity = velocity.normalized * projectileSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Bullet")
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.collider, true);
        }

        if (collision.collider.tag == "Player")
        {
            player.GetComponent<PlayerStats>().takeDamage();
            playEffect();
        }

        if(collision.collider.tag == "Wall")
        {
            playEffect();
        }


        void playEffect(){
            GameObject effectObject = (GameObject)Instantiate(ImpactEffect, transform.position, Quaternion.Euler(0f,(int)direction.magnitude*-1f, 0f));
            effectObject.GetComponent<Renderer>().material = material;
            Destroy(effectObject, 2f);
            Destroy(gameObject);
            
        }
    }
}
