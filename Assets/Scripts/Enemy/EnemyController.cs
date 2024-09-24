using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed;

    public float detectionRange;

    bool canSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        canSeePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //calculates where the player is located
        detectionRange = Vector2.Distance(transform.position, player.transform.position);
        //moves the enemy towards the player
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if (gameObject.CompareTag("Wall"))
        {
            canSeePlayer = false;   
        }

        if(detectionRange < 10 && canSeePlayer)
        {
            canSeePlayer = true;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Destroy(collision.gameObject);
        }
    }
}
