using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGirlBoyCup : MonoBehaviour
{
    Component textObject;
    [SerializeField][TextArea] string NPCtext;
    [SerializeField][TextArea] string NPCtextAlternative;

    void Start()
    {
        textObject = GetComponentInChildren<TextMesh>();
        if (textObject != null)
        {
            textObject.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GlobalVariablesKitchen.kitchenQuestFinished && NPCtextAlternative != "")
            {
                textObject.GetComponent<TextMesh>().text = NPCtextAlternative;
            }
            else if (GlobalVariablesKitchen.kitchenQuestFinished && NPCtextAlternative == "")
            {
                textObject.GetComponent<TextMesh>().text = "Hello";
            }
            else
            {
                textObject.GetComponent<TextMesh>().text = NPCtext;
            }
            textObject.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.gameObject.SetActive(false);
        }
    }
}
