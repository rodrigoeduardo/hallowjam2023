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

        blairStartPosition = blair.GetComponent<BlairBehaviour>().spawnPosition;
        noiteStartPosition = noite.GetComponent<NoiteBehaviour>().spawnPosition;
        ResetLevel();
    }

    public void ResetLevel()
    {

        blair.transform.position = blair.GetComponent<BlairBehaviour>().spawnPosition;
        noite.transform.position = noite.GetComponent<NoiteBehaviour>().spawnPosition;
    }
}
