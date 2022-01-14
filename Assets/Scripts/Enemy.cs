using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //Orbe de vida
    public GameObject healthPrefab;
    public Transform enemy;



    //Barra de vida
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        //Colocando el maximo de vida del enemigo
        healthBar.setMaxHealth(maxHealth);
    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        //Al recibir da�o, se actualiza la barra de vida.
        healthBar.setHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            dropHealth();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void dropHealth()
    {
        Instantiate(healthPrefab, enemy.position, enemy.rotation);
    }

}
