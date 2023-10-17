using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaseEventEmmiter : MonoBehaviour
{
    public string[] dialog; /* ARMAZENA AS FALAS DO DIÁLOGO DESSE EVENTO */
    public int index; /* ARMAZENA O ÍNDICE ATUAL DA FALA NO DIÁLOGO */
    public bool hasNoiteArrived; /* ARMAZENA SE NOITE JÁ CHEGOU NO EVENTO */
    public bool hasBlairArrived; /* ARMAZENA SE BLAIR JÁ CHEGOU NO EVENTO */
    public bool hasPlayed; /* ARMAZENA SE O EVENTO JÁ FOI TOCADO OUTRA VEZ */
    public GameObject DialogBox; /* ARMAZENA A CAIXA DE DIÁLOGO */
    private bool hasReleased;
    public bool fimFase;
    // Start is called before the first frame update
    void Start()
    {
        hasNoiteArrived = hasBlairArrived = hasPlayed = false;
        index = 0;
        hasReleased = true;

    }

    // Update is called once per frame
    void Update()
    {
        /* SE PUDER INICIAR O EVENTO, INICIA */
        if (canPlay())
        {
            if (index == 0)
            {
                if (dialog[index].Split("|").Length >= 2)
                {
                    string locutor = dialog[index].Split("|")[0];
                    string text = dialog[index].Split("|")[1];
                    if (locutor != null)
                    {
                        DialogBox.transform.GetChild(0).GetComponent<Portrait>().resolveTextPortrait(locutor);
                    }
                    DialogBox.transform.GetChild(1).GetComponent<Text>().text = text;
                }
                else DialogBox.transform.GetChild(1).GetComponent<Text>().text = dialog[index];
            }
            resolveDialog();    /* PASSA O DIÁLOGO */
            if (index == dialog.Length)
            { /* SE O DIÁLOGO TIVER ACABADO */
                if (fimFase)
                {    /* SE FOR O FIM DA FASE */
                    GameObject.Find("Main Camera").GetComponent<CameraController>().changePosition = true; /* MUDA A CÂMERA PARA A PRÓXIMA */
                }
            }
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
        if (Input.GetKey(KeyCode.Space) && hasReleased && index < dialog.Length)
        {
            hasReleased = false;
            index++;
            if (index != dialog.Length)
            {
                if (dialog[index].Split("|").Length >= 2)
                {
                    string locutor = dialog[index].Split("|")[0];
                    string text = dialog[index].Split("|")[1];
                    if (locutor != null)
                    {
                        DialogBox.transform.GetChild(0).GetComponent<Portrait>().resolveTextPortrait(locutor);
                    }
                    DialogBox.transform.GetChild(1).GetComponent<Text>().text = text;
                }
                else
                {
                    DialogBox.transform.GetChild(1).GetComponent<Text>().text = dialog[index];
                }
            }
        }
        else if (index == dialog.Length)
        {
            DialogBox.SetActive(false);
            index = 0;
            Destroy(gameObject);
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            hasReleased = true;
        }
    }
}
