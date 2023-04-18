using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleLogic : MonoBehaviour
{
    GameObject glow;
    AudioSource spellSound;
    bool soundPlayed = false;
    void Start()
    {
        glow = GameObject.FindGameObjectWithTag("bottleGlow");
        spellSound = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Destroy(glow);
            destroyThorns();
            if (!soundPlayed)
            {
                spellSound.Play();
                soundPlayed = true;
            }
        }
    }

    void destroyThorns()
    {
        foreach (Transform child in transform)
        {
            Animator thornAnimator = child.gameObject.GetComponent<Animator>();
            if (thornAnimator != null)
            {
                child.gameObject.GetComponent<Animator>().enabled = true;
                child.gameObject.GetComponent<DestroyAfterDelay>().enabled = true;
            }
        }
    }
}
