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
    CapsuleCollider2D heroGeneralCollider;
    Component heroText;
    Component deathSound;


    void Start()
    {
        GlobalVariables.heroCanMove = true;
        heroFeetCollider = gameObject.GetComponent<BoxCollider2D>();
        heroGeneralCollider = gameObject.GetComponent<CapsuleCollider2D>();
        heroRigidBody = gameObject.GetComponent<Rigidbody2D>();
        heroAnimator = gameObject.GetComponent<Animator>();
        heroText = gameObject.transform.Find("Text");
        deathSound = gameObject.transform.Find("DeathSound");
        Cursor.visible = false;
    }

    void Update()
    {
        Run();
        FlipSprite();
    }
    void OnMove(InputValue value)
    {
        if (!GlobalVariables.heroCanMove) { return; }
        moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        heroAnimator.SetBool("isRunning", Mathf.Abs(heroRigidBody.velocity.x) > Mathf.Epsilon);
        Vector2 playerValocity = new Vector2(moveInput.x * velocityMultiplier, heroRigidBody.velocity.y);
        heroRigidBody.velocity = playerValocity;
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
        if (!GlobalVariables.heroCanMove) { return; }
        if (heroGeneralCollider.IsTouchingLayers(LayerMask.GetMask("Board")))
        {
            heroText.GetComponent<TextMesh>().text = "Looking for a Witcher?";
            heroText.gameObject.SetActive(true);
            Invoke("hideHeroText", 3f);
            return;
        }
        if (value.isPressed && (heroFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))))
        {
            heroRigidBody.velocity += new Vector2(heroRigidBody.velocity.x * velocityMultiplier, jumpHeight);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            deathSound.GetComponent<AudioSource>().Play();
            Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Invoke("reloadLevel", 2.8f);
        }
    }
    void hideHeroText()
    {
        heroText.gameObject.SetActive(false);
    }
    void reloadLevel()
    {
        Initiate.Fade("Level3", Color.black, 2f);
    }
}

