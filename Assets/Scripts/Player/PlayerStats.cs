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
    public GameObject vestPickUpSFX;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    void TakeDamage(int amount)
    {
        //takes away health when the player is hit
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
            Instantiate(vestPickUpSFX, transform.position, Quaternion.identity);
        }
        //player takes one hit point if hit by an enemy bullet
        if(collision.CompareTag("EnemyBullet"))
        {
            TakeDamage(1);
        }
        //player instantly dies if hit by the tank enemy
        if(collision.CompareTag("EnemyTank"))
        {
            TakeDamage(3);
        }
    }

  
}
