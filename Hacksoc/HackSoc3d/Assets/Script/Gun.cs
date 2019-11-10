using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public float damage;
    public float radius;
    public float projectileSpeed;
    public GameObject bulletPrefab;

    private Transform firePoint;
    private float fireCountDown;
    private bool canFire = false;
    private void Start()
    {
        firePoint = transform.Find("FirePoint").transform;
        fireCountDown = 1f / fireRate;
    }


    // Update is called once per frame
    void Update()
    {
        if (fireCountDown <= 0f)
        {
            canFire = true;
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;

    }


        // Update is called once per frame
    public void Shoot(PlayerShoot.Direction _direction)
    {
        if (canFire)
        {
            canFire = false;
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().getgunStats(_direction, damage, radius, projectileSpeed);
            Physics.IgnoreCollision((GetComponentInParent<Collider>()), bullet.GetComponent<Collider>(), true);
        }
    }
}
