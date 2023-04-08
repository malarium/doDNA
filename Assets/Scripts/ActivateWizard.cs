using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWizard : MonoBehaviour
{
    Component wizard;
    void Start()
    {
        wizard = gameObject.transform.Find("Wizard");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            wizard.gameObject.SetActive(true);
        }
    }
}