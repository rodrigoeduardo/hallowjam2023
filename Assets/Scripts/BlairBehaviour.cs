using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlairBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    private string currentAnimation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            sr.flipX = false;
            animator.Play("blairMoving");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            sr.flipX = true;
            animator.Play("blairMoving");
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.Play("blairIdle");
        }
    }

    void Jump()
    {
        bool isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    void SetCurrentAnimation(string newAnimation)
    {
        if (currentAnimation.Equals("blairIdle") && newAnimation.Equals("blairPushing"))
        {
            currentAnimation = newAnimation;
        }
        else
        {

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            animator.Play("blairPushing");
        }
    }
}
