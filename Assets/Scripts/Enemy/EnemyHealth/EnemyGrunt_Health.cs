using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt_Health : MonoBehaviour
{
    public int currentHealth = 1;
    public int maxHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //play death animation
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }
}
