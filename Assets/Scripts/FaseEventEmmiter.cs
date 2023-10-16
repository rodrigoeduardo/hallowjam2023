using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaseEventEmmiter : MonoBehaviour
{
    public string[] dialog; /* ARMAZENA AS FALAS DO DIÁLOGO DESSE EVENTO */
    public int index; /* ARMAZENA O ÍNDICE ATUAL DA FALA NO DIÁLOGO */
    private bool hasNoiteArrived; /* ARMAZENA SE NOITE JÁ CHEGOU NO EVENTO */
    private bool hasBlairArrived; /* ARMAZENA SE BLAIR JÁ CHEGOU NO EVENTO */
    private bool hasPlayed; /* ARMAZENA SE O EVENTO JÁ FOI TOCADO OUTRA VEZ */
    public GameObject DialogBox; /* ARMAZENA A CAIXA DE DIÁLOGO */
    private bool hasReleased;
    // Start is called before the first frame update
    void Start()
    {
        hasNoiteArrived = hasBlairArrived = hasPlayed = false;
        index = 0;
        hasReleased = true;
        DialogBox.transform.GetChild(1).GetComponent<Text>().text = dialog[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay())
        {
            resolveDialog();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* MARCANDO OS PERSONAGENS QUE CHEGAM NO EVENTO */
        if (collision.CompareTag("Blair"))
        {
            hasBlairArrived = true;
        }
        if (collision.CompareTag("Noite"))
        {
            hasNoiteArrived = true;
        }
    }

    /* RETORNA SE O EVENTO PODE SER INICIADO */
    bool canPlay()
    {
        if (hasBlairArrived == true && hasNoiteArrived == true && hasPlayed == false)
        {
            return true;
        }
        return false;
    }

    /* LÓGICA DE EXBIBIR O PRÓXIMO DIÁLOGO DO ARRAY */
    void resolveDialog()
    {
        DialogBox.SetActive(true);
        if(Input.GetKey(KeyCode.Space) && hasReleased && index < dialog.Length){
            hasReleased = false;
            index ++;
            if(index != dialog.Length){
                DialogBox.transform.GetChild(1).GetComponent<Text>().text = dialog[index];
            }
        }
        else if(index == dialog.Length){
            DialogBox.SetActive(false);
            hasPlayed = false;
        }
        else if(!Input.GetKey(KeyCode.Space)){
            hasReleased = true;
        }
    }
}
