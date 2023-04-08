using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToiletTask : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !GlobalVariablesPlocekTask.toiletPaperQuestStarted)
        {
            GlobalVariablesPlocekTask.toiletPaperQuestStarted = true;
        }
    }
}
