using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;

public class FaseEventEmmiter : MonoBehaviour
{
    public string[] dialog; /* ARMAZENA AS FALAS DO DIÁLOGO DESSE EVENTO */
    public int index; /* ARMAZENA O ÍNDICE ATUAL DA FALA NO DIÁLOGO */
    public bool hasNoiteArrived; /* ARMAZENA SE NOITE JÁ CHEGOU NO EVENTO */
    public bool hasBlairArrived; /* ARMAZENA SE BLAIR JÁ CHEGOU NO EVENTO */
    public bool hasPlayed; /* ARMAZENA SE O EVENTO JÁ FOI TOCADO OUTRA VEZ */
    public GameObject DialogBox; /* ARMAZENA A CAIXA DE DIÁLOGO */
    private bool hasReleased;
    public bool fimFase; /* ARMAZENA SE O EVENTO É O FIM DE UMA FASE */
    private string fmodEventPath;
    private bool hasRenderedText;
    // Start is called before the first frame update
    void Start()
    {
        hasNoiteArrived = hasBlairArrived = hasPlayed = false;
        index = 0;
        hasReleased = true;
        hasRenderedText = true;
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
                else resolveDialog();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* MARCANDO OS PERSONAGENS QUE CHEGAM NO EVENTO */
        if (collision.gameObject.CompareTag("Blair"))
        {
            hasBlairArrived = true;
        }
        if (collision.gameObject.CompareTag("Noite"))
        {
            hasNoiteArrived = true;
        }
        if(hasNoiteArrived && hasBlairArrived){
            GetComponent<BoxCollider2D>().isTrigger = true;
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
        if (Input.GetKey(KeyCode.Space) && hasReleased && index < dialog.Length && hasRenderedText == true)
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
                    StartCoroutine(mountPhrase(text));
                }
                else
                {
                    StartCoroutine(mountPhrase(dialog[index]));
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

    IEnumerator mountPhrase(string phrase){
        DialogBox.transform.GetChild(1).GetComponent<Text>().text = "";
        char[] letters = phrase.ToCharArray();
        string newString = "";
        int letterIndex = 0;
        Debug.Log(letterIndex);
        Debug.Log(letters.Length);
        Debug.Log(Input.GetKey(KeyCode.Space));
        while(letterIndex < letters.Length){
            DialogBox.transform.GetChild(1).GetComponent<Text>().text += letters[letterIndex];
            newString = DialogBox.transform.GetChild(1).GetComponent<Text>().text;
            letterIndex ++;
            fmodEventPath = "event:/SFX/Player/Blair talk";
            FMOD.Studio.EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEventPath);
            eventInstance.start();
            Debug.Log(newString.Length);
            Debug.Log(DialogBox.transform.GetChild(1).GetComponent<Text>().text.Length);
            if(letterIndex == letters.Length){
                hasRenderedText = true;
            }
            else hasRenderedText = false;
            yield return new WaitForSeconds(0.05f);
        }
        if(Input.GetKey(KeyCode.Space) && letterIndex > 5){
            letterIndex = letters.Length;
            DialogBox.transform.GetChild(1).GetComponent<Text>().text += phrase;
        }
    }
}
