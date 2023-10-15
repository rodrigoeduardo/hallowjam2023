using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] dialog;
    public GameObject dialogBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Blair")){
            dialogBox.GetComponent<DialogController>().dialog = dialog;
            dialogBox.GetComponent<DialogController>().index = 0;
            dialogBox.GetComponent<DialogController>().UpdateDialogDisplay();
            dialogBox.SetActive(true);
        }
    }
}
