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
        currentAnimation = "blairIdle";
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        animator.Play(currentAnimation);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            sr.flipX = false;
            SetCurrentAnimation("blairMoving", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            sr.flipX = true;
            SetCurrentAnimation("blairMoving", false);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            SetCurrentAnimation("blairIdle", false);
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

    void SetCurrentAnimation(string newAnimation, bool isNotPushingAnymore)
    {
        if (!currentAnimation.Equals("blairPushing") || isNotPushingAnymore)
        {
            currentAnimation = newAnimation;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SetCurrentAnimation("blairPushing", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SetCurrentAnimation("blairMoving", true);
        }
    }
}
