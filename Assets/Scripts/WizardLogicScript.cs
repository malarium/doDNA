using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLogicScript : MonoBehaviour
{
    Component textObject;
    GameObject catObject;
    bool isTalking = false;
    [SerializeField][TextArea] string WizardText1;
    [SerializeField][TextArea] string WizardText2;
    [SerializeField][TextArea] string WizardText3;
    [SerializeField] ParticleSystem sparksEffect;
    void Start()
    {
        textObject = gameObject.transform.Find("WizardText");
        catObject = GameObject.FindGameObjectWithTag("Cat");

        textObject.gameObject.SetActive(false);
        if (!GlobalVariablesPlocekTask.wizardVisible)
        {
            gameObject.SetActive(false);
        }

    }

    void Update()
    {
        if (GlobalVariablesPlocekTask.wizardVisible)
        {
            gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isTalking)
        {
            if (!GlobalVariablesPlocekTask.catAppeared)
            {

                isTalking = true;
                showFirstText();
                Invoke("showSecondText", 3f);
                Invoke("showThirdText", 6f);
            }
            else
            {
                textObject.gameObject.SetActive(false);
                textObject.GetComponent<TextMesh>().text = "Alakazam!";
                textObject.gameObject.SetActive(true);
                sparksEffect.Play();
                Invoke("hideText2", 1.5f);
            }
        }

    }

    void showFirstText()
    {
        GlobalVariables.heroCanMove = false;
        textObject.gameObject.SetActive(false);
        textObject.GetComponent<TextMesh>().text = WizardText1;
        textObject.gameObject.SetActive(true);
    }
    void showSecondText()
    {
        textObject.gameObject.SetActive(false);
        textObject.GetComponent<TextMesh>().text = WizardText2;
        textObject.gameObject.SetActive(true);
    }
    void showThirdText()
    {
        textObject.gameObject.SetActive(false);
        textObject.GetComponent<TextMesh>().text = WizardText3;
        textObject.gameObject.SetActive(true);
        Invoke("hideText", 3f);

    }

    void hideText()
    {
        textObject.gameObject.SetActive(false);
        isTalking = false;
        sparksEffect.Play();
        Invoke("callTheCat", 2f);
    }

    void hideText2()
    {
        textObject.gameObject.SetActive(false);
    }

    void callTheCat()
    {
        catObject.GetComponent<Renderer>().enabled = true;
        catObject.GetComponent<CapsuleCollider2D>().enabled = true;
        catObject.GetComponent<WalkAutomatically>().enabled = true;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 30f, 0f);
        GlobalVariablesPlocekTask.catAppeared = true;
        GlobalVariables.heroCanMove = true;
    }
}
