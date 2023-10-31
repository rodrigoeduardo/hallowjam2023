using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    public string[] dialog; /* ARMAZENA AS FALAS DO DIÁLOGO DESSE EVENTO */
    public int index; /* ARMAZENA O ÍNDICE ATUAL DA FALA NO DIÁLOGO */
    private bool hasReleased;
    private string fmodEventPath;
    private bool hasRenderedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
