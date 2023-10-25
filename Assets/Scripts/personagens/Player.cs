using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public GameObject dialogBox;
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    protected Animator animator;

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
        if (!dialogBox.activeSelf)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                sr.flipX = false;
                animator.SetBool("isMoving", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                sr.flipX = true;
                animator.SetBool("isMoving", true);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                animator.SetBool("isMoving", false);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isMoving", false);
        }
    }

    void Jump()
    {
        bool isGrounded = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Ground"));

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
