using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int moveSpeed = 4;
    float moveX;
    bool grounded;
    Rigidbody2D rb;
    public float jumpSpeed = 1.0f;
    public int jumpCount = 0;
    public int maxJumps = 2;
    bool jump;
    int clickerCount;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveX = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }
    public void Jump()
    {
        if (grounded && jumpCount < maxJumps)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumpCount++;
            GetComponent<SpriteRenderer>().color = Color.red;


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
            GetComponent<SpriteRenderer>().color = Color.white;
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

        }
    }
    public void Colorc()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
    public void trick()
    {
        
    }
}
