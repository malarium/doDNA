using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamilaTalking : MonoBehaviour
{
    Component textObject;
    [SerializeField][TextArea] string noFoosballWon;
    [SerializeField][TextArea] string noCupBrought;
    [SerializeField][TextArea] string allDone;
    void Start()
    {
        textObject = gameObject.transform.Find("KamilaText");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.gameObject.SetActive(false);
            bool foosballWon = PlayerPrefs.HasKey("won");

            if (!foosballWon)
            {
                textObject.GetComponent<TextMesh>().text = noFoosballWon;
            }
            else if (!GlobalVariablesKitchen.kitchenQuestFinished)
            {
                textObject.GetComponent<TextMesh>().text = noCupBrought;
            }
            else
            {
                textObject.GetComponent<TextMesh>().text = allDone;
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