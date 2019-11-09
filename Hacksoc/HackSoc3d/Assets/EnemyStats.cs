using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public string name = "enemy";
    public float startingSpeed = 20f;
    public float startingHealth = 100f;

    public float health;
    private void Start()
    {
        health = startingHealth;
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log("health = " + health);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
