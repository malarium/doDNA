using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLocalScale : MonoBehaviour
{
    GameObject parentWizard;

    void Start()
    {
        parentWizard = gameObject.transform.parent.gameObject;
    }
    void Update()
    {
        if (parentWizard.transform.localScale.x < 0)
        {

            gameObject.transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(1f, 1f);
        }
    }
}
