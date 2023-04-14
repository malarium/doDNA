using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBatHanging : MonoBehaviour
{
    Rigidbody2D batBody;
    Animator batAnimator;
    void Start()
    {
        batBody = gameObject.GetComponent<Rigidbody2D>();
        batAnimator = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            batBody.gravityScale = 2f;
            Invoke("Disappear", 3f);
        }
    }

    void Disappear()
    {
        batAnimator.SetBool("disappear", true);
        Invoke("DeleteObject", 1f);
    }

    void DeleteObject()
    {
        Destroy(gameObject);
    }

}
