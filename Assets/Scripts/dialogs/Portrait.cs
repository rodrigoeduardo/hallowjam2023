using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portrait : MonoBehaviour
{
    private Image portraitImage;

    // Start is called before the first frame update
    void Start()
    {
        portraitImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resolveTextPortrait(string locutor)
    {
        portraitImage = gameObject.GetComponent<Image>();
        Sprite newSprite;
        switch (locutor)
        {
            case "Blair":
                newSprite = Resources.Load<Sprite>("Sprites/Blair/BlairPortrait");
                Debug.Log(newSprite);
                portraitImage.sprite = newSprite;
                break;
            case "Noite":
                newSprite = Resources.Load<Sprite>("Sprites/Noite/NoitePortrait");
                Debug.Log(newSprite);
                portraitImage.sprite = newSprite;
                break;
        }
    }
}
