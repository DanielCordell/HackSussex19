using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public float rateOfFire = 1f;
    public Transform pointToShoot;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
     Direction ShootDirection;
    private float fireCountDown;
    private bool canFire = false;



    private void Start()
    {
        fireCountDown = 1f / rateOfFire;
    }
    // Update is called once per frame
    void Update()
    {
        if (fireCountDown <= 0f)
        {
            canFire = true;
            fireCountDown = 1f / rateOfFire;
        }
        fireCountDown -= Time.deltaTime;





        if (Input.GetKey(KeyCode.UpArrow))  // If the player is pressing the "d" key
        {
            ShootDirection = Direction.UP;
            transform.rotation = Quaternion.Euler(0f,0f,0f);
            Shoot();
        }

        if (Input.GetKey(KeyCode.DownArrow))  // If the player is pressing the "d" key
        {
            ShootDirection = Direction.DOWN;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Shoot();
        }

        if (Input.GetKey(KeyCode.LeftArrow))  // If the player is pressing the "d" key
        {
            ShootDirection = Direction.LEFT;
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            Shoot();
        }

        if (Input.GetKey(KeyCode.RightArrow))  // If the player is pressing the "d" key
        {
            ShootDirection = Direction.RIGHT;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            Shoot();


        }

        canFire = false;


        void Shoot()
        {
            if (canFire)
            {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, pointToShoot.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().getDirection(ShootDirection);
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), bullet.GetComponent<Collider>(), true);
            }
               
            //bullet.set
        }
    }
}
