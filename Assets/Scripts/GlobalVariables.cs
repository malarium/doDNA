using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static string takenItem;


    public static GameObject takenObject;

    public static string currentItem;

    public static Rigidbody2D takenObjectBody;
    public static SpriteRenderer takenObjectRenderer;
    public static bool platformLevelStarted = false;
    public static bool heroCanMove = true;

    public static Vector3 platformerStartingPoint = new Vector3(1.3f, 1.67f, 0);
    // public static Vector3 platformerStartingPoint = new Vector3(107.3f, -35f, 0);
    // public static Vector3 platformerStartingPoint = new Vector3(82f, -4f, 0);
    // public static Vector3 platformerStartingPoint = new Vector3(396.04f, -36.34f, 0);

    public static void DropObject(Vector2 coords)
    {
        if (GlobalVariables.takenObject)
        {
            GlobalVariables.takenObject.SetActive(true);
            GlobalVariables.takenObject.transform.position = coords;
            GlobalVariables.takenObjectBody = GlobalVariables.takenObject.GetComponent<Rigidbody2D>();
            GlobalVariables.takenObjectBody.velocity = new Vector2(0f, 0f);
        }
        PlayerPrefs.SetString("takenItem", "");
        GlobalVariables.takenItem = "";
        GlobalVariables.currentItem = "";
        GlobalVariables.takenObject = null;
        GlobalVariables.takenObjectRenderer = null;
    }

    public static void TakeObject()
    {
        GlobalVariables.takenItem = GlobalVariables.currentItem;
        GlobalVariables.takenObject = GameObject.FindGameObjectWithTag(GlobalVariables.takenItem);
        if (GlobalVariables.takenObject != null)
        {

            GlobalVariables.takenObjectRenderer = GlobalVariables.takenObject.GetComponent<SpriteRenderer>();
        }
        PlayerPrefs.SetString("takenItem", GlobalVariables.takenItem);
        if (GlobalVariables.takenObject.GetComponent<WalkAutomatically>() != null)
        {
            GlobalVariables.takenObject.GetComponent<WalkAutomatically>().enabled = false;
        }
        GlobalVariables.takenObject.SetActive(false);
    }

    public static void resetGame()
    {
        GlobalVariables.platformerStartingPoint = new Vector3(1.3f, 1.67f, 0);
        GlobalVariablesKitchen.kitchenQuestStarted = false;
        GlobalVariablesKitchen.kitchenQuestFinished = false;
        GlobalVariablesPlocekTask.doorOpened = false;
        GlobalVariablesPlocekTask.toiletPaperQuestStarted = false;
        GlobalVariablesPlocekTask.toiletPaperQuestFinished = false;
        GlobalVariablesPlocekTask.wizardVisible = false;
        GlobalVariablesPlocekTask.catAppeared = false;
        GlobalVariablesPlocekTask.catMissionComplete = false;
        GlobalVariablesPlocekTask.plocekDoorOpened = false;
        GlobalVariablesPlocekTask.initiallyApproachedByPlayer = false;
        GlobalOlaTask.chocolateAppeared = false;
        GlobalOlaTask.vacuumTaskStarted = false;
        GlobalOlaTask.vacuumTaskCompleted = false;
        GlobalOlaTask.kamilaVisible = false;
    }
}

public static class GlobalVariablesKitchen
{
    public static bool kitchenQuestStarted = false;
    public static bool kitchenQuestFinished = false;
}

public static class GlobalVariablesPlocekTask
{
    public static bool doorOpened = false;
    public static bool toiletPaperQuestStarted = false;
    public static bool toiletPaperQuestFinished = false;
    public static bool wizardVisible = false;
    public static bool catAppeared = false;
    public static bool catMissionComplete = false;
    public static bool plocekDoorOpened = false;
    public static bool initiallyApproachedByPlayer = false;
}

public static class GlobalOlaTask
{
    public static bool chocolateAppeared = false;
    public static bool vacuumTaskStarted = false;
    public static bool vacuumTaskCompleted = false;
    public static bool kamilaVisible = false;
}

