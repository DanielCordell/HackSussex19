using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerStats : MonoBehaviour
{

    public int startHealth = 3;
    public float iFrames = 10f;
    public GameObject startingGun;
    [HideInInspector]
    public static int health;
    public static float playerSpeed;

    private GameObject healthBar;
    [HideInInspector]
    public GameObject gun;
    // Start is called before the first frame update

    private float timeRemaining;

    private bool beenHit;
    void Awake ()
    {
        health = startHealth;
        beenHit = false;

    }

    private void Start()
    {
        healthBar = GameObject.Find("HealthBarPlayer");
        if (gun == null)
        {
            gun = (GameObject)Instantiate(startingGun, transform.Find("GunSpawn").transform);

        }
    }
    // Update is called once per frame
    public void takeDamage(int damage = 1)
    {
        if (!beenHit)
        {
            health -= damage;
            healthBar.GetComponent<HealthDisplay>().UpdateDisplay();
            if (health <= 0)
            {
                Debug.Log("gameOver");
            }
            beenHit = true;
            timeRemaining = iFrames;
        }

    }

    public void Update()
    {
        if (beenHit)
        {
            
            if(timeRemaining <= 0)
            {
                beenHit = false;
            }

            timeRemaining -= Time.deltaTime;
        }
    }

}
