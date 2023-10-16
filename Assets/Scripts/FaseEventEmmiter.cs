using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseEventEmmiter : MonoBehaviour
{
    public string[] dialog; /* ARMAZENA AS FALAS DO DIÁLOGO DESSE EVENTO */
    public int index; /* ARMAZENA O ÍNDICE ATUAL DA FALA NO DIÁLOGO */
    private bool hasNoiteArrived; /* ARMAZENA SE NOITE JÁ CHEGOU NO EVENTO */
    private bool hasBlairArrived; /* ARMAZENA SE BLAIR JÁ CHEGOU NO EVENTO */
    private bool hasPlayed; /* ARMAZENA SE O EVENTO JÁ FOI TOCADO OUTRA VEZ */
    // Start is called before the first frame update
    void Start()
    {
        hasNoiteArrived = hasBlairArrived = hasPlayed = false;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* RETORNA SE O EVENTO PODE SER INICIADO */
    bool canPlay(){ 
        if(hasBlairArrived == true && hasNoiteArrived == true && hasPlayed == false){
            return true;
        }
        return false;
    }
}
