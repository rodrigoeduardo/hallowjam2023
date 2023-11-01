using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portrait : MonoBehaviour
{
    public Sprite portraitImageBlair;
    public Sprite portraitImageNoite;
    public Sprite portraitImageBruxa;
    public Sprite portraitImageJoaninha;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resolveTextPortrait(string locutor)
    {
        Sprite newSprite;
        Debug.Log("teste");
        switch (locutor)
        {
            case "Blair":
                gameObject.GetComponent<Image>().sprite = portraitImageBlair;
                break;
            case "Noite":
                gameObject.GetComponent<Image>().sprite = portraitImageNoite;
                break;
            case "Joaninha":
                gameObject.GetComponent<Image>().sprite = portraitImageJoaninha;
                break;
            case "Bruxa":
                gameObject.GetComponent<Image>().sprite = portraitImageJoaninha;
                break;
        }
    }
}
