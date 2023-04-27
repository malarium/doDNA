using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLogic : MonoBehaviour
{
    Component textObject;
    string sceneName;
    string playBtnTxt = "PLAY";
    void Start()
    {
        Cursor.visible = true;
        textObject = gameObject.transform.Find("Text");
        textObject.gameObject.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Level4")
        {
            playBtnTxt = "AGAIN";
        }
    }

    void OnMouseEnter()
    {
        if (gameObject.name == "BtnExit")
        {
            textObject.GetComponent<TextMesh>().text = "EXIT";
        }
        else if (gameObject.name == "BtnPlay")
        {
            textObject.GetComponent<TextMesh>().text = playBtnTxt;
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
            GlobalVariables.resetGame();
            Initiate.Fade("Level1", Color.black, 1f);
        }
    }

    void OnMouseExit()
    {
        textObject.gameObject.SetActive(false);
    }
}
