using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLogic : MonoBehaviour
{
    Component textObject;
    void Start()
    {
        Cursor.visible = true;
        textObject = gameObject.transform.Find("Text");
        textObject.gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        if (gameObject.name == "BtnExit")
        {
            textObject.GetComponent<TextMesh>().text = "EXIT";
        }
        else if (gameObject.name == "BtnPlay")
        {
            textObject.GetComponent<TextMesh>().text = "PLAY";
        }
        textObject.gameObject.SetActive(true);
    }
    void OnMouseDown()
    {
        if (gameObject.name == "BtnExit")
        {
            Application.Quit();
        }
        else if (gameObject.name == "BtnPlay")
        {
            Initiate.Fade("Level1", Color.black, 1f);
        }
    }

    void OnMouseExit()
    {
        textObject.gameObject.SetActive(false);
    }
}
