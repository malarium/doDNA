using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    [SerializeField] string requiredObjectTag = "";
    Animator doorAnimator;
    AudioSource audioSource;
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (GlobalVariablesPlocekTask.plocekDoorOpened)
        {
            requiredObjectTag = "";
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (requiredObjectTag == "")
        {
            if (other.tag == "Player")
            {
                doorAnimator.SetBool("open", true);
                Invoke("closeDoor", 1.1f);
                audioSource.Play();

            }
        }

        if (requiredObjectTag != "")
        {
            if (other.tag == "Player" && GlobalVariables.takenItem == requiredObjectTag)
            {
                doorAnimator.SetBool("open", true);
                Invoke("closeDoor", 1.1f);
                GetComponent<SlideDoor>().requiredObjectTag = "";
                Destroy(GlobalVariables.takenObject);
                requiredObjectTag = "";
                GlobalVariablesPlocekTask.plocekDoorOpened = true;
            }
        }
    }

    void closeDoor()
    {
        doorAnimator.SetBool("open", false);

    }

}
