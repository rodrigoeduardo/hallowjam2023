using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool pressed;

    Vector2 startPosition;

    private void Start()
    {

        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !collision.CompareTag("Obstacle")) return;
        transform.position = new Vector2(startPosition.x, startPosition.y - 0.2f);
        pressed = true;
        FMOD.Studio.EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ambient/Button");
        eventInstance.start();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !collision.CompareTag("Obstacle")) return;
        transform.position = startPosition;
        pressed = false;
        FMOD.Studio.EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ambient/Button");
        eventInstance.start();
    }
}
