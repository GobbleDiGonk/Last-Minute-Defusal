using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunplay : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int ammo;
    public UIManager uiManager;
    public bool canFire;
    public bool canReload;
    public int reserveAmmo;
  

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //makes the playermodel move around to follow the mouse

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        //input to spawn and fire bullets
        //decreases the amount of ammo the player has

        if (Input.GetKeyDown(KeyCode.Mouse0)&& canFire)
        {
            Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
         
            ammo -= 1;
            uiManager.UpdateAmmoCounter(ammo);
            canFire = false;
            canReload = true;
                   
        }
      

        //checks if the player has no ammo in the cylinder
        if (ammo > 0)
        {
            canFire = true;
            canReload = false;
        }

        //input to insert a load into the cylinder
        if (Input.GetKeyDown(KeyCode.R) && canReload)
        {
            ammo += 6;
            reserveAmmo -= 6;
            uiManager.UpdateAmmoCounter(ammo);
            uiManager.UpdateReserveCounter(reserveAmmo);
        }

        //checks if the cylinder is full to prevent reloads
        if (ammo == 6)
        {
            canReload = true;
        }

        //checks if the player is completely out of ammo to prevent reloading and shooting
        if (reserveAmmo == 0 && ammo == 0 && canReload)
        {
            canReload = false;         
        }

        if (reserveAmmo > 0)
        {
            canReload = true;
        }
    }

    //tells the game to give the player ammo in their reserves upon collision with an object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PowerUp_Ammo"))
        {
            reserveAmmo += 12;
            uiManager.UpdateReserveCounter(reserveAmmo);
            Destroy(collision.gameObject);
        }
    }



}
