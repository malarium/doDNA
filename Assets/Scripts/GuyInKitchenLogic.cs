using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyInKitchenLogic : MonoBehaviour
{
    GameObject textObject;
    GameObject hiddenCup;
    [SerializeField][TextArea] string QuestText = "Can you help me find my cup?";
    [SerializeField][TextArea] string BadObjectText = "What an abomination. Begone! I need A CUP!";
    [SerializeField][TextArea] string RewardText = "A, thank you good man!";
    void Start()
    {
        textObject = GameObject.FindGameObjectWithTag("KitchenText");
        textObject.SetActive(false);
        hiddenCup = GameObject.FindGameObjectWithTag("HiddenCup");
        if (!GlobalVariablesKitchen.kitchenQuestFinished)
        {
            hiddenCup.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GlobalVariables.takenItem == "Cup" || GlobalVariablesKitchen.kitchenQuestFinished)
            {
                textObject.GetComponent<TextMesh>().text = RewardText;
                textObject.SetActive(true);
                hiddenCup.SetActive(true);
                GlobalVariablesKitchen.kitchenQuestFinished = true;
                if (GlobalVariables.takenItem == "Cup")
                {
                    GlobalVariables.DropObject(new Vector2(0f, 0f));
                    Destroy(GlobalVariables.takenObject);
                }
            }
            else if (GlobalVariablesKitchen.kitchenQuestStarted && GlobalVariables.takenItem != "Cup" && GlobalVariables.takenItem != "")
            {
                textObject.GetComponent<TextMesh>().text = BadObjectText;
                textObject.SetActive(true);
            }
            else
            {
                GlobalVariablesKitchen.kitchenQuestStarted = true;
                textObject.GetComponent<TextMesh>().text = QuestText;
                textObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.SetActive(false);
        }
    }
}
