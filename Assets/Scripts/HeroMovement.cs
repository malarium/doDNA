using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] float velocityMultiplier = 1f;
    Rigidbody2D heroRigidBody;
    Vector2 moveInput;
    Animator heroAnimator;
    GameObject takenItemBox;
    GameObject takenObjectWrapper;

    void Start()
    {
        // PlayerPrefs.SetString("takenItem", "");
        GlobalVariables.currentItem = "";
        GlobalVariables.takenItem = "";
        GlobalVariables.heroCanMove = true;
        heroRigidBody = GetComponent<Rigidbody2D>();
        heroAnimator = GetComponent<Animator>();
        takenItemBox = GameObject.FindGameObjectWithTag("ItemBox");
        takenObjectWrapper = GameObject.FindGameObjectWithTag("ItemBoxWrapper");
        if (PlayerPrefs.HasKey("takenItem") && PlayerPrefs.GetString("takenItem") != "")
        {
            GlobalVariables.currentItem = PlayerPrefs.GetString("takenItem");
            GlobalVariables.TakeObject();
            placeTakenObjectImageIntoTheBox();
        }
        Cursor.visible = false;
    }

    void Update()
    {
        heroAnimator.SetBool("isRunning", (Mathf.Abs(heroRigidBody.velocity.x) > Mathf.Epsilon) || Mathf.Abs(heroRigidBody.velocity.y) > Mathf.Epsilon);

        if (GlobalVariables.takenObjectRenderer)
        {
            takenObjectWrapper.SetActive(true);
        }
        else
        {
            takenObjectWrapper.SetActive(false);
        }
    }
    void OnMove(InputValue value)
    {
        if (!GlobalVariables.heroCanMove) { return; }
        moveInput = value.Get<Vector2>();
        Vector2 playerValocity = new Vector2(moveInput.x * velocityMultiplier, moveInput.y * velocityMultiplier);
        heroRigidBody.velocity = playerValocity;


        if (moveInput.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        if (moveInput.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    void OnTake(InputValue value)
    {
        if (GlobalVariables.currentItem != "" && GlobalVariables.currentItem != "NPC" && GlobalVariables.takenItem == "")
        {
            GlobalVariables.TakeObject();
            placeTakenObjectImageIntoTheBox();
        }
        else
        {
            GlobalVariables.DropObject(gameObject.transform.position);
        }
        Debug.Log("Taken: " + GlobalVariables.takenItem);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tag: " + other.tag);
        if (other.tag == "Untagged") { return; }

        GlobalVariables.currentItem = other.tag;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Dropped: " + other.tag);
        if (other.tag == "Untagged") { return; }
        GlobalVariables.currentItem = "";
    }
    void placeTakenObjectImageIntoTheBox()
    {
        Image imageToReplaceInTakenItemBox = takenItemBox.GetComponent<Image>();
        Sprite imagetoBePlacedInTakenItemBox = GlobalVariables.takenObjectRenderer.sprite;
        if (imagetoBePlacedInTakenItemBox != null && imageToReplaceInTakenItemBox != null)
        {
            imageToReplaceInTakenItemBox.overrideSprite = imagetoBePlacedInTakenItemBox;
        }
    }
}

