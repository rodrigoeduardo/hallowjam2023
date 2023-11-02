using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Vector3 position1;
    public Vector3 position2;
    [SerializeField]
    float speed;

    public bool changePosition;

    private void FixedUpdate()
    {

        if (changePosition)
            transform.position = Vector3.MoveTowards(transform.position, position2, speed);
        else
            transform.position = Vector3.MoveTowards(transform.position, position1, speed);
    }
}
