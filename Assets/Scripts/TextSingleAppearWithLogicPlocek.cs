using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSingleAppearWithLogicPlocek : MonoBehaviour
{
    Component textObject;
    [SerializeField][TextArea] string NPCtextIfFalse;
    [SerializeField][TextArea] string NPCtextIfTrue;
    [SerializeField][TextArea] string NPCtextFindWizardReminder;
    void Start()
    {
        textObject = GetComponentInChildren<TextMesh>();
        textObject.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GlobalVariablesPlocekTask.catMissionComplete)
            {
                textObject.GetComponent<TextMesh>().text = NPCtextIfTrue;
            }
            else if (GlobalVariablesPlocekTask.wizardVisible && !GlobalVariablesPlocekTask.catMissionComplete)
            {
                textObject.GetComponent<TextMesh>().text = NPCtextFindWizardReminder;
            }
            else
            {
                textObject.GetComponent<TextMesh>().text = NPCtextIfFalse;
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