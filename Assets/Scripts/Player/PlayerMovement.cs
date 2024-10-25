using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //the movement speed of the player
    [SerializeField] float speed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCooldown;
    bool isDashing;
    bool canDash;

    Vector2 moveDirection;
    
    private Rigidbody2D rb;

    private void Start()
    {
        canDash = true;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //assigns the horizontal values to the variable called horizontal
        float moveX = Input.GetAxisRaw("Horizontal");
        //assigns the vertical values to the variable called vertical
        float moveY = Input.GetAxisRaw("Vertical");
        //returns the player back to the update state
        if (isDashing)
        {
            return;
        }

        //checks if the player has inputted space
        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    //IEnumerator is used to process the dash mechanic
    private IEnumerator Dash()
    {
        //checks if the player can dash and if they are dashing
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        //Activates a timer for how long the player dashes
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        //starts timer for cooldown, allows the player to dash
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
