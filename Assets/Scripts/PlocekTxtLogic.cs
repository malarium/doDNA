using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlocekTxtLogic : MonoBehaviour
{
    Component textObject;
    [SerializeField][TextArea] string PlocekNoShoeText;
    [SerializeField][TextArea] string PlocekWithCatText;
    void Start()
    {
        textObject = GetComponentInChildren<TextMesh>();
        textObject.GetComponent<TextMesh>().text = "Waaah, sob sob!";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.gameObject.SetActive(false);
            if ((GlobalVariables.takenObject && GlobalVariables.takenObject.name == "Cat") || GlobalVariablesPlocekTask.catMissionComplete)
            {
                textObject.GetComponent<TextMesh>().text = PlocekWithCatText;
                if (!GlobalVariablesPlocekTask.catMissionComplete)
                {
                    finalizeCatQuest();
                }
            }
            else
            {
                textObject.GetComponent<TextMesh>().text = PlocekNoShoeText;
                if (!GlobalVariablesPlocekTask.wizardVisible)
                {
                    GlobalVariablesPlocekTask.wizardVisible = true;
                }
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

    void finalizeCatQuest()
    {
        Destroy(GlobalVariables.takenObject);
        GlobalVariablesPlocekTask.catMissionComplete = true;
    }
}
