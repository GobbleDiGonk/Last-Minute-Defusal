using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;
    private Rigidbody2D rb;
    public GameObject playerDeathSprite;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(playerDeathSprite, transform.position, Quaternion.identity);
            SceneManager.LoadScene("DeathMenu");
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PowerUp_Vest"))
        {
            currentHealth += 3;
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("EnemyBullet"))
        {
            TakeDamage(1);
        }

        if(collision.CompareTag("EnemyTank"))
        {
            TakeDamage(3);
        }
    }

  
}
