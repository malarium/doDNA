using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayComeBackWhisper : MonoBehaviour
{
    AudioSource sound;
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
        }
    }
}
