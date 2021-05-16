using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HP2DHack : MonoBehaviour
{
    //public int maxHealth = 100;
    public int maxHealth;
    public int currentHealth;
    public Text remainingHealth;

    public HealthBar_HP2D healthBar;

    void Start()
    {
        maxHealth = 999999;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        remainingHealth.text = currentHealth.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        remainingHealth.text = currentHealth.ToString();
        if (currentHealth == 0)
        {
            remainingHealth.text = "You died.";
        }
    }
}
