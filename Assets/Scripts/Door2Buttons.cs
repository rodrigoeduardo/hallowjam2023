using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Buttons : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    Button button2;
    [SerializeField]
    float speed;
    [SerializeField]
    float maxDistance;

    Vector2 startPosition;
    int direction = 1;
    float distance;

    private void Start()
    {

        startPosition = transform.position;
    }

    void Update()
    {

        if (button.pressed || button2.pressed) direction = -1;
        else direction = 1;
        distance = Vector2.Distance(startPosition, transform.position);

        if((distance < maxDistance && direction == -1) || (distance > 0.05f && direction == 1))
        {

            transform.Translate(new Vector3(0, Time.deltaTime * speed * direction));
        }
    }
}
