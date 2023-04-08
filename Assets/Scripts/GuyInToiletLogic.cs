using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyInToiletLogic : MonoBehaviour
{
    Component textObject;
    Component paper;

    GameObject toiletDoor;
    GameObject key;
    Component tioletCeilings;
    [SerializeField][TextArea] string NPCtext1;
    [SerializeField][TextArea] string NPCtext2;
    [SerializeField][TextArea] string NPCtext3;
    bool isTalking = false;
    void Start()
    {
        textObject = GetComponentInChildren<TextMesh>();
        paper = gameObject.transform.Find("Paper");
        tioletCeilings = gameObject.transform.Find("ToiletsGrid");
        toiletDoor = GameObject.Find("toilet_door");
        key = GameObject.FindGameObjectWithTag("PlocekKey");
        textObject.gameObject.SetActive(false);
        paper.gameObject.SetActive(false);
        if (GlobalVariablesPlocekTask.toiletPaperQuestStarted)
        {
            tioletCeilings.gameObject.SetActive(false);
            paper.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (
            GlobalVariablesPlocekTask.toiletPaperQuestFinished
            && !key.gameObject.GetComponent<Renderer>().isVisible
            && !toiletDoor.gameObject.GetComponent<Renderer>().isVisible
        )
        {
            paper.gameObject.SetActive(false);
            gameObject.SetActive(false);
            toiletDoor.transform.position = new Vector3(6.58f, -37.54f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && GlobalVariablesPlocekTask.toiletPaperQuestStarted && !GlobalVariablesPlocekTask.toiletPaperQuestFinished)
        {
            if (GlobalVariables.takenItem != "toiletpaper")
            {
                tioletCeilings.gameObject.SetActive(false);
                if (!isTalking)
                {
                    isTalking = true;
                    showTextFirst();
                    Invoke("showTextSecond", 3f);
                    Invoke("showTextThird", 6f);
                    Invoke("hideText", 9f);
                }
            }
            else
            {
                textObject.GetComponent<TextMesh>().text = "Now go away. I need privacy!";
                GlobalVariables.DropObject(new Vector2(gameObject.transform.position.x - 1f, gameObject.transform.position.y));
                GlobalVariablesPlocekTask.toiletPaperQuestFinished = true;
                textObject.gameObject.SetActive(true);
                Invoke("hideText", 3f);
            }

        }
    }

    void showTextFirst()
    {
        textObject.gameObject.SetActive(false);
        textObject.GetComponent<TextMesh>().text = NPCtext1;
        textObject.gameObject.SetActive(true);
        GlobalVariablesPlocekTask.toiletPaperQuestStarted = true;
        paper.gameObject.SetActive(true);
    }
    void showTextSecond()
    {
        textObject.gameObject.SetActive(false);
        textObject.GetComponent<TextMesh>().text = NPCtext2;
        textObject.gameObject.SetActive(true);

    }
    void showTextThird()
    {
        textObject.gameObject.SetActive(false);
        textObject.GetComponent<TextMesh>().text = NPCtext3;
        textObject.gameObject.SetActive(true);
        isTalking = false;
    }

    void hideText()
    {
        textObject.gameObject.SetActive(false);
    }
}
