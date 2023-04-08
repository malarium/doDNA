using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    Rigidbody2D paddleBody;
    Vector2 moveInput;
    AudioSource ping;
    [SerializeField] float velocityMultiplier = 1f;
    void Start()
    {
        paddleBody = GetComponent<Rigidbody2D>();
        ping = GetComponent<AudioSource>();
    }

    void OnMove(InputValue value)
    {
        if (PointsLogic.timeRemaining <= 0)
        { return; }
        moveInput = value.Get<Vector2>();
        Vector2 playerValocity = new Vector2(moveInput.x * velocityMultiplier, moveInput.y * velocityMultiplier);
        paddleBody.velocity = playerValocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            ping.Play();
        }
    }
}
