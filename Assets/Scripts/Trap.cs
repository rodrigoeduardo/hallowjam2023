using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    LevelController levelController;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Blair") || collision.CompareTag("Noite"))
        {

            levelController.ResetLevel();
        }
    }
}
