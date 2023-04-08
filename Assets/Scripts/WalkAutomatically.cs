using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAutomatically : MonoBehaviour
{
    [SerializeField] float xSpeed = 2;
    [SerializeField] float ySpeed = 0;
    float xVel;
    float yVel;

    Rigidbody2D objRigidBody;
    void Start()
    {
        objRigidBody = GetComponent<Rigidbody2D>();
        xVel = xSpeed;
        yVel = ySpeed;
    }
    void Update()
    {
        Vector2 walkingObjVelocity = new Vector2(xVel, yVel);
        objRigidBody.velocity = walkingObjVelocity;
        if (xVel < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (xVel > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            xVel = -xVel;
            yVel = -yVel;
        }
        else
        {
            xVel = 0;
            yVel = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        xVel = Random.value > 0.5f ? xSpeed : -xSpeed;
        yVel = Random.value > 0.5f ? ySpeed : -ySpeed;
    }
}
