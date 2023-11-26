using System.Collections;
using System.Collections.Generic;
using Main;
using UnityEngine;

public class Tower5GHealth : MonoBehaviour, IVulnerable
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
