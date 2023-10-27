using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiteBehaviour : Player
{
    [SerializeField]
    bool doubleJump;
    override public void Jump()
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

        if (Input.GetKeyDown(jumpButton) && isGrounded)
        {
            FMOD.Studio.EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Actions/Jump");
            eventInstance.start();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        else if (Input.GetKeyDown(jumpButton) && !isGrounded && doubleJump)
        {
            FMOD.Studio.EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Actions/DoubleJump");
            eventInstance.start();
            doubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
