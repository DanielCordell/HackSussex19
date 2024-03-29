﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float fireRate;
    private float damage;
    private float radius;
    private float projectileSpeed;
    private float color;

    PlayerShoot.Direction direction;
    public Collider playerCollider;

    public GameObject ImpactEffect;

    public void getgunStats(PlayerShoot.Direction _direction, float _damage, float _radius, float _projectileSpeed)
    {
        direction = _direction;
        damage = _damage;
        radius = _radius;
        projectileSpeed = _projectileSpeed;
        transform.localScale =new Vector3 (radius,radius,radius);

    }

    private void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;

        if (direction == PlayerShoot.Direction.LEFT)  // If the player is pressing the "d" key
        {
            // Add a force to the right
            velocity += Vector3.left * Time.deltaTime;
        }

        if (direction == PlayerShoot.Direction.RIGHT)  // If the player is pressing the "a" key
        {
            // Add a force to the left
            velocity += Vector3.right * Time.deltaTime;
        }

        if (direction == PlayerShoot.Direction.UP)  // If the player is pressing the "d" key
        {
            // Add a force to the right
            velocity += Vector3.forward * Time.deltaTime;
        }

        if (direction == PlayerShoot.Direction.DOWN)  // If the player is pressing the "a" key
        {
            // Add a force to the left
            velocity += Vector3.back * Time.deltaTime;
        }

        GetComponent<Rigidbody>().velocity = velocity.normalized * projectileSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Bullet")
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.collider, true);
        }



        if (collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<EnemyStats>().takeDamage(damage);
            playEffect();
        }


        if(collision.collider.tag == "Wall")
        {
            playEffect();
        }


        void playEffect(){
            GameObject effectObject = (GameObject)Instantiate(ImpactEffect, transform.position, Quaternion.Euler(0f,(int)direction*-1f, 0f));
            Destroy(effectObject, 2f);
            Destroy(gameObject);
            
        }
    }
}
