using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    public float bulletVelocity;
    private Rigidbody2D rb;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - transform.position;
        Vector3 rotation = transform.position - player.transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletVelocity;

        float rot = Mathf.Atan2(rotation.y , rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
