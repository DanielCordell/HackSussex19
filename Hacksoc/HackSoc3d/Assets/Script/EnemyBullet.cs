using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float radius;
    private float projectileSpeed;

    Vector3 direction;
    public Collider PlayerCollider;

    public GameObject ImpactEffect;

    public void setStats(Vector3 _direction, float _radius, float _projectileSpeed, Material material)
    {
        direction = _direction;
        radius = _radius;
        projectileSpeed = _projectileSpeed;
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
