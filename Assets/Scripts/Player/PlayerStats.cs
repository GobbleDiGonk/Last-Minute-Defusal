using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth >= 0)
        {
            //isDead
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PowerUp_Vest"))
        {
            currentHealth += 3;
        }
    }

}
