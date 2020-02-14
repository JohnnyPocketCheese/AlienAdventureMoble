﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bruh : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJumps = 2;
    Animator anim;

    float initialMoveSpeed;
    public float sprintMultiplier = 2;
    float sprintSpeed;
    bool sprintKeyDown = false;

    private void Start()
    {
        anim = GetComponent<Animator>();

        initialMoveSpeed = moveSpeed;
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed * moveX;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)// && grounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (sprintKeyDown == false)
            {
                sprintKeyDown = true;
                moveSpeed = moveSpeed * sprintMultiplier;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = initialMoveSpeed;
            sprintKeyDown = false;
        }
        anim.SetBool("sprint", sprintKeyDown); //make sure to save and surrender
        anim.SetBool("grounded", grounded);
        anim.SetFloat("x", velocity.x);
        anim.SetFloat("y", velocity.y);
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
        if (grounded || !grounded)
        {
            jumpCount++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = false;
            //jumpCount = 0;
        }
    }

}
