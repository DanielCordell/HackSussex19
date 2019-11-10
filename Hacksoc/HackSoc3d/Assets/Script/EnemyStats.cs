using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyStats : MonoBehaviour
{
    public string enemyName = "enemy";
    public float startingSpeed = 20f;
    public float startingHealth = 100f;
    [HideInInspector]
    public float health;
    public GameObject deathEffect;

    public Image healthBar;
    public Text nameText;
    private void Start()
    {
        nameText.text = enemyName;
        health = startingHealth;
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log("health = " + health);
        healthBar.fillAmount = health / startingHealth;
        if(health <= 0)
        {
            Die();

        }
    }

    public void Die()
    {
        GameObject effectObject = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effectObject, 4f);
        Destroy(gameObject);
    }

}
