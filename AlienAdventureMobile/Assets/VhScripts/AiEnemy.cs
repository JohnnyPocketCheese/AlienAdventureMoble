using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{
    [SerializeField]
    Transform player;
    public float agroRange;
    public float moveSpeed;
    public Animator animator;
    public bool startChasing;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("x", GetComponent<Rigidbody2D>().velocity.x);
        animator.SetFloat("y", GetComponent<Rigidbody2D>().velocity.y);

        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer < agroRange)
        {
            startChasing = true;
            StartCoroutine(Anim());
            ChasePlayer();
        }
        else
        {
            startChasing = false;
            StopChasingPlayer();
        }
    }
    public IEnumerator Anim()
    {
        print("Chase");
        animator.SetBool("ChasePlayer", true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("ChasePlayer", false);
        animator.SetBool("ChasingPlayer", true);
    }
    public void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            //enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    public void StopChasingPlayer()
    {
        print("Stop");
        rb2d.velocity = Vector2.zero;
    }
}
