using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5f;
    public float damage = 10f;
    PlayerShoot.Direction direction ;
    public Collider Collider;
    public void getDirection(PlayerShoot.Direction _direction)
    {
        direction = _direction;
    }

    private void FixedUpdate()
    {
        if(direction == PlayerShoot.Direction.UP)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }

        if (direction == PlayerShoot.Direction.DOWN)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }

        if (direction == PlayerShoot.Direction.LEFT)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        if (direction == PlayerShoot.Direction.RIGHT)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<EnemyStats>().takeDamage(damage);
            Destroy(gameObject);
        }

        if(collision.collider.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}
