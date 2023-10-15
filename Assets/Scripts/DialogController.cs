using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMOD.Studio;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public string[] dialog;
    public int index;
    public GameObject dialogObject;
    public GameObject locutorObject;
    private string locutor;
    private string text;
    bool hasReleasedKey = true;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        UpdateDialogDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X) && index < dialog.Length && hasReleasedKey == true)
        {
            hasReleasedKey = false;
            EventInstance passDialog = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/UI/Select");
            passDialog.start();
            UpdateDialogDisplay();
        }
        else if (index == dialog.Length)
        {
            gameObject.SetActive(false);
        }
        if(Input.GetKey(KeyCode.X) == false)
        {
            hasReleasedKey = true;
        }
    }

    // Atualiza a exibição do diálogo
    public void UpdateDialogDisplay()
    {
        string[] splitDialog = dialog[index].Split("|");
        if (splitDialog.Length >= 2)
        {
            locutor = splitDialog[0];
            text = splitDialog[1];
        }
        else
        {
            locutor = "";
            text = dialog[index];
        }
        dialogObject.GetComponent<Text>().text = text;
        locutorObject.GetComponent<Text>().text = locutor;
        index++;
    }
}
