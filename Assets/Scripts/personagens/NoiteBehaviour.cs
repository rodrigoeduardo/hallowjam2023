using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiteBehaviour : Player
{
    [SerializeField]
    bool doubleJump;
    void Jump()
    {
        bool isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));
        if (isGrounded)
        {
            doubleJump = true;
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !isGrounded && doubleJump)
        {
            doubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
