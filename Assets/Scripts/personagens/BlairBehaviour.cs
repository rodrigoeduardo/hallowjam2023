using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlairBehaviour : Player
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("isPushing", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("isPushing", false);
        }
    }
}
