using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlocekDeskScript : MonoBehaviour
{
    Component chocolate;
    Component text;
    Component tilemap;
    TextMesh textMesh;
    bool deskTalkingInitialized = false;
    bool isTalking = false;

    [SerializeField][TextArea] string deskText1;
    [SerializeField][TextArea] string deskText2;
    [SerializeField][TextArea] string deskText3;
    void Start()
    {
        chocolate = gameObject.transform.Find("Chocolate");
        text = gameObject.transform.Find("Text");
        tilemap = gameObject.transform.Find("Grid");
        textMesh = text.GetComponent<TextMesh>();
        text.gameObject.SetActive(false);

        if (!GlobalOlaTask.vacuumTaskCompleted)
        {
            chocolate.gameObject.SetActive(false);
        }

        if (GlobalOlaTask.vacuumTaskStarted)
        {
            tilemap.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (GlobalVariablesPlocekTask.catMissionComplete && !GlobalVariablesPlocekTask.initiallyApproachedByPlayer && !deskTalkingInitialized)
        {
            deskTalkingInitialized = true;

            Invoke("DeskTalking", 0.25f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && GlobalVariablesPlocekTask.catMissionComplete)
        {
            if (!GlobalOlaTask.vacuumTaskStarted)
            {

                text.gameObject.SetActive(false);

                GlobalVariablesPlocekTask.initiallyApproachedByPlayer = true;
                if (!isTalking)
                {
                    Invoke("DeskText1", 0.2f);
                }
            }
            else
            {
                if ((GlobalVariables.takenObject && GlobalVariables.takenObject.name == "VacuumCleaner"))
                {
                    Destroy(GlobalVariables.takenObject);
                    chocolate.gameObject.SetActive(true);
                    textMesh.text = "There! Grab the payment!";
                    text.gameObject.SetActive(true);
                    GlobalOlaTask.vacuumTaskCompleted = true;
                }
                else if (GlobalVariables.currentItem != "Cleaner" && !GlobalOlaTask.vacuumTaskCompleted)
                {
                    if (!isTalking)
                    {
                        Invoke("DeskText1", 0.2f);
                        text.gameObject.SetActive(true);
                    }
                }
                else
                {
                    textMesh.text = "Like every Brit I'm clean and neat!";
                    text.gameObject.SetActive(true);
                    Invoke("hideText", 2f);
                }
            }
        }
    }

    void DeskTalking()
    {
        if (!GlobalVariablesPlocekTask.initiallyApproachedByPlayer)
        {
            text.gameObject.SetActive(false);
            textMesh.text = "Oy, bloke!";
            text.gameObject.SetActive(true);
            Invoke("DeskTalking2", 2f);
        }
    }
    void DeskTalking2()
    {
        if (!GlobalVariablesPlocekTask.initiallyApproachedByPlayer)
        {
            text.gameObject.SetActive(false);
            textMesh.text = "C'mon'ere mate!";
            text.gameObject.SetActive(true);
            Invoke("DeskTalking", 2f);
        }
    }

    void DeskText1()
    {

        isTalking = true;
        textMesh.text = deskText1;
        text.gameObject.SetActive(true);
        tilemap.gameObject.SetActive(false);
        GlobalOlaTask.vacuumTaskStarted = true;
        Invoke("DeskText2", 3f);

    }
    void DeskText2()
    {

        text.gameObject.SetActive(false);
        textMesh.text = deskText2;
        text.gameObject.SetActive(true);
        Invoke("DeskText3", 4f);

    }
    void DeskText3()
    {

        text.gameObject.SetActive(false);
        textMesh.text = deskText3;
        text.gameObject.SetActive(true);
        Invoke("hideText", 3f);

    }

    void hideText()
    {
        text.gameObject.SetActive(false);
        isTalking = false;
    }
}
