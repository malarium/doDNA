using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    Rigidbody2D enemyBody;
    [SerializeField] float enemySpeed = 0.1f;

    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody2D>();
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
}
