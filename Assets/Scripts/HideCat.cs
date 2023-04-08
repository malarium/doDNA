using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCat : MonoBehaviour
{
    private void Start()
    {
        if (!GlobalVariablesPlocekTask.catAppeared)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<WalkAutomatically>().enabled = false;
        }
    }
}