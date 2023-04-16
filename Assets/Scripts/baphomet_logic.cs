using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baphomet_logic : MonoBehaviour
{
    Animator animator;
    GameObject hero;
    Animator heroAnimator;
    Rigidbody2D heroBody;
    BoxCollider2D baphometTriggerCollider;
    AudioSource whisper;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        hero = GameObject.FindGameObjectWithTag("Player");
        heroBody = hero.gameObject.GetComponent<Rigidbody2D>();
        heroAnimator = hero.gameObject.GetComponent<Animator>();
        baphometTriggerCollider = gameObject.GetComponent<BoxCollider2D>();
        whisper = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            heroAnimator.SetBool("isRunning", false);
            GlobalVariables.heroCanMove = false;
            hero.transform.localScale = new Vector3(1f, 1f, 1f);
            baphometTriggerCollider.enabled = false;
            whisper.Play();
            Invoke("lookAtPlayer", 1f);
        }
    }
    void lookAtPlayer()
    {
        animator.enabled = true;
        Invoke("heroMove", 5f);
    }

    void heroMove()
    {
        GlobalVariables.heroCanMove = true;
    }
}
