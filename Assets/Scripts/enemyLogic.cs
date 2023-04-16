using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    Rigidbody2D enemyBody;
    [SerializeField] float enemySpeed = 0.1f;
    Animator animator;

    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        if (gameObject.name == "bomb_timeout" && animator != null)
        {
            Invoke("disappear", 9f);
        }
        if (gameObject.name == "bomb_timeout" || gameObject.name == "bomb")
        {
            enemyBody.gravityScale = 20f;
        }
    }

    void Update()
    {
        enemyBody.velocity = new Vector2(enemySpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, 0f);
            enemySpeed = -enemySpeed;
        }
    }

    void disappear()
    {
        animator.enabled = true;
        Invoke("destroy", 1f);
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
