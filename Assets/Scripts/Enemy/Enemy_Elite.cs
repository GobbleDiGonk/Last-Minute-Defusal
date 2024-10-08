using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Elite : MonoBehaviour
{
    [SerializeField] float shootingTimer;
    private GameObject player;
    private bool hasLineOfSight = false;
    private Rigidbody2D rb;
    private Vector3 playerPos;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        shootingTimer += Time.deltaTime;
        if(shootingTimer > 1.25 && hasLineOfSight)
        {
            shootingTimer = 0;
            Shoot();
        }
        //checks if the enemy has light of sight of the player
        if (hasLineOfSight)
        {
            Vector3 rotation = player.transform.position - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        //Sends out raycasts out from the enemy to player
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            if (hasLineOfSight)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
}
