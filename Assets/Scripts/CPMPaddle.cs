using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPMPaddle : MonoBehaviour
{
    [SerializeField] float CPMPaddleSpeed = 12f;
    Rigidbody2D CPMPaddleBody;
    AudioSource pong;
    void Start()
    {
        CPMPaddleBody = GetComponent<Rigidbody2D>();
        pong = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PointsLogic.timeRemaining > 0)
        {
            CPMPaddleBody.velocity = new Vector2(0f, CPMPaddleSpeed);
        }
        else
        {
            CPMPaddleBody.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CPMPaddleSpeed = -CPMPaddleSpeed;
        if (other.gameObject.tag == "ball")
        {
            pong.Play();
        }
    }
}
