using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    GameObject hero;
    Animator heroAnimator;
    Component mikkeTwo;
    Component bolt;
    Component heroText;
    Component mikkeText;
    bool laptopReached = false;
    AudioSource thunder;
    [SerializeField] GameObject flyStopPoint;
    [SerializeField] float speed = 1f;
    [SerializeField][TextArea] string mikkeText1;
    [SerializeField][TextArea] string mikkeText2;
    [SerializeField][TextArea] string mikkeText3;
    [SerializeField][TextArea] string mikkeText4;
    [SerializeField][TextArea] string mikkeText5;
    [SerializeField][TextArea] string mikkeText6;
    [SerializeField][TextArea] string mikkeText7;
    [SerializeField][TextArea] string mikkeText8;
    [SerializeField][TextArea] string heroText1;
    void Start()
    {
        hero = GameObject.Find("Hero");
        heroAnimator = hero.gameObject.GetComponent<Animator>();
        heroText = hero.gameObject.transform.Find("Text");
        mikkeTwo = gameObject.transform.Find("MikkeAgain");
        mikkeTwo.gameObject.SetActive(false);
        mikkeText = mikkeTwo.transform.Find("Text");
        mikkeText.gameObject.SetActive(false);
        bolt = gameObject.transform.Find("BoltEnd");
        thunder = gameObject.GetComponent<AudioSource>();
        killBolt();
    }

    void Update()
    {
        if (laptopReached)
        {

            float step = speed * Time.deltaTime;
            mikkeTwo.gameObject.transform.position = Vector3.MoveTowards(mikkeTwo.gameObject.transform.position, flyStopPoint.gameObject.transform.position, step);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GlobalVariables.heroCanMove = false;
        heroAnimator.SetBool("isRunning", false);
        heroAnimator.SetBool("isJumping", false);
        heroAnimator.SetBool("isZoomed", false);
        heroAnimator.SetBool("isDone", true);
        hero.transform.localScale = new Vector3(-1, 1, 1);
        mikkeTwo.gameObject.SetActive(true);
        laptopReached = true;
        Invoke("Speak1", 15f);
        Invoke("boltHit", 4f);
    }

    void Speak1()
    {
        mikkeText.GetComponent<TextMesh>().text = mikkeText1;
        showMikkeText();
        Invoke("Speak2", 6f);
    }

    void Speak2()
    {
        hideMikkeText();
        Invoke("Speak3", 1f);
    }
    void Speak4()
    {
        hideMikkeText();
        Invoke("Speak5", 1f);
    }
    void Speak3()
    {
        mikkeText.GetComponent<TextMesh>().text = mikkeText2;
        showMikkeText();
        Invoke("Speak4", 6f);
    }
    void Speak5()
    {
        mikkeText.GetComponent<TextMesh>().text = mikkeText3;
        showMikkeText();
        Invoke("Speak6", 5f);
    }
    void Speak6()
    {
        hideMikkeText();
        Invoke("Speak7", 3f);
    }

    void Speak7()
    {
        heroText.GetComponent<TextMesh>().text = heroText1;
        showHeroText();
        Invoke("hideHeroText", 3f);
        Invoke("Speak8", 4f);
    }

    void Speak8()
    {
        mikkeText.GetComponent<TextMesh>().text = mikkeText4;
        showMikkeText();
        Invoke("hideMikkeText", 4f);
        Invoke("Speak9", 5f);
    }
    void Speak9()
    {
        mikkeText.GetComponent<TextMesh>().text = mikkeText5;
        showMikkeText();
        Invoke("hideMikkeText", 3f);
        Invoke("Speak10", 4f);
    }
    void Speak10()
    {
        mikkeText.GetComponent<TextMesh>().text = mikkeText6;
        showMikkeText();
        Invoke("hideMikkeText", 3f);
        Invoke("Speak11", 4f);
    }
    void Speak11()
    {
        mikkeText.GetComponent<TextMesh>().text = mikkeText7;
        showMikkeText();
        Invoke("hideMikkeText", 6f);
        Invoke("boltHit", 6f);
        Invoke("Speak12", 12f);
    }
    void Speak12()
    {
        mikkeText.GetComponent<TextMesh>().text = mikkeText8;
        showMikkeText();
        Invoke("hideMikkeText", 5f);
        Invoke("End", 7f);
    }

    void End()
    {
        Initiate.Fade("Level4", Color.black, 3f);

    }

    void boltHit()
    {
        bolt.gameObject.SetActive(true);
        Invoke("killBolt", 0.7f);
        thunder.Play();
    }

    void killBolt()
    {
        bolt.gameObject.SetActive(false);
    }
    void showMikkeText()
    {
        mikkeText.gameObject.SetActive(true);
    }
    void hideMikkeText()
    {
        mikkeText.gameObject.SetActive(false);
    }
    void showHeroText()
    {
        heroText.gameObject.SetActive(true);
    }
    void hideHeroText()
    {
        heroText.gameObject.SetActive(false);
    }
}
