using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlaScript : MonoBehaviour
{
    Component textObject;
    Component kamilaTextObject;
    GameObject kamila;
    bool isTalking = false;
    [SerializeField][TextArea] string NeedChocolate;
    [SerializeField][TextArea] string GotChocolate;

    void Start()
    {
        textObject = gameObject.transform.Find("Text");
        kamila = GameObject.FindWithTag("Kamila");
        kamilaTextObject = gameObject.transform.Find("KamilaText");
        textObject.gameObject.SetActive(false);
        kamila.gameObject.SetActive(false);
        if (GlobalOlaTask.kamilaVisible)
        {
            kamila.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isTalking)
        {
            isTalking = true;
            if (GlobalOlaTask.kamilaVisible)
            {
                textObject.GetComponent<TextMesh>().text = "Omnomnom";
                textObject.gameObject.SetActive(true);
                return;
            }
            if (GlobalVariables.takenObject && GlobalVariables.takenObject.name == "Chocolate")
            {
                textObject.GetComponent<TextMesh>().text = GotChocolate;
                Destroy(GlobalVariables.takenObject);
                GlobalVariables.DropObject(Vector2.zero);
                Invoke("showKamila", 3f);
            }
            else
            {
                textObject.GetComponent<TextMesh>().text = NeedChocolate;
            }

            textObject.gameObject.SetActive(true);
        }
    }

    void showKamila()
    {
        textObject.gameObject.SetActive(false);
        kamila.gameObject.SetActive(true);
        GlobalOlaTask.kamilaVisible = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.gameObject.SetActive(false);
            isTalking = false;
        }
    }
}
