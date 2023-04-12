using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HeroMovementPlatform : MonoBehaviour
{
    [SerializeField] float velocityMultiplier = 1f;
    [SerializeField] float jumpHeight = 5f;
    Rigidbody2D heroRigidBody;
    Vector2 moveInput;
    Animator heroAnimator;
    BoxCollider2D heroFeetCollider;

    void Start()
    {
        GlobalVariables.heroCanMove = true;
        heroFeetCollider = gameObject.GetComponent<BoxCollider2D>();
        heroRigidBody = gameObject.GetComponent<Rigidbody2D>();
        heroAnimator = gameObject.GetComponent<Animator>();
        Cursor.visible = false;
    }

    void Update()
    {
        Run();
        FlipSprite();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        if (heroFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {

            heroAnimator.SetBool("isRunning", Mathf.Abs(heroRigidBody.velocity.x) > Mathf.Epsilon);

            Vector2 playerValocity = new Vector2(moveInput.x * velocityMultiplier, heroRigidBody.velocity.y);
            heroRigidBody.velocity = playerValocity;
        }
    }
    void FlipSprite()
    {
        if (Mathf.Abs(heroRigidBody.velocity.x) > Mathf.Epsilon)
        {

            transform.localScale = new Vector2(Mathf.Sign(heroRigidBody.velocity.x), 1f);
        }
    }

    void OnTake(InputValue value)
    {
        if (value.isPressed && (heroFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))))
        {
            heroRigidBody.velocity += new Vector2(0f, jumpHeight);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tag: " + other.tag);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Dropped: " + other.tag);
    }
}

