using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject blair;
    [SerializeField]
    GameObject noite;
    
    Vector2 blairStartPosition;
    Vector2 noiteStartPosition;

    private void Start()
    {

        blairStartPosition = blair.transform.position;
        noiteStartPosition = noite.transform.position;
        ResetLevel();
    }

    public void ResetLevel()
    {

        blair.transform.position = blairStartPosition;
        noite.transform.position = noiteStartPosition;
    }
}
