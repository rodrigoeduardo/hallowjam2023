using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiteBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    private Rigidbody2D rb;

    [SerializeField]
    bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void Jump()
    {
        bool isGrounded = Physics2D.Linecast(transform.position, new Vector2(0.1f, 0.4f), LayerMask.GetMask("Ground"));
        if (isGrounded) doubleJump = true;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && !isGrounded && doubleJump)
        {
            doubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
