using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public enum Direction
    {
        UP = 180,
        DOWN = 360,
        LEFT = 270,
        RIGHT = 90
    }



    public float rateOfFire = 1f;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
     Direction ShootDirection;


    private void Update()
    {
        
    


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



        void Shoot()
        {
            GetComponent<PlayerStats>().gun.GetComponent <Gun> ().Shoot(ShootDirection); ;

        }
    }
}
