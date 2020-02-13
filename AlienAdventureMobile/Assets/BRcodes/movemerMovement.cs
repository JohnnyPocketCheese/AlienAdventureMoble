﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJumps = 2;
    Animator anim;
    float moveX = 0;
    float moveY = 0;
    Rigidbody2D rb;

    public Joystick joystick;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (joystick.Horizontal >= 0.2f)
        {
            moveX = 1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            moveX = -1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().color = Color.blue;

        }
        else
        {
            moveX = 0;
        }
        //float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        anim.SetBool("grouneded", grounded);
        anim.SetFloat("x", velocity.x);
        anim.SetFloat("y", velocity.y);
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)//&& grounded)
        {
            Jump();
            jumpCount++;
        }
        float x = Input.GetAxisRaw("Horizontal");
        if(x == 0)
        {
            anim.SetInteger("x", 0);
        }
        else
        {
            anim.SetInteger("x", 1);
        }
        if(velocity.y > 0)
        {
            anim.SetInteger("y", 1);
        }
        else if (velocity.y < 0)
        {
            anim.SetInteger("y", -1);
        }
        else
        {
            anim.SetInteger("y", 0);
        }
        if(x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void Jump()
    {
        if(jumpCount < maxJumps)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
            anim.SetBool("grounded", grounded);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
            anim.SetBool("grounded", grounded);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = false;
            anim.SetBool("grounded", grounded);
        }
    }
    public void MoveLeft()
    {
        moveX = -1;
    }
    public void MoveRight()
    {
        moveX = 1;
    }
    public void Stopmove()
    {
        moveX = 0;
    }
    public void jump()
    {
        Jump();
        jumpCount++;
    }
}