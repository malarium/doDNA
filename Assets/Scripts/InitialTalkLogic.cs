using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InitialTalkLogic : MonoBehaviour
{

    Animator heroAnimator;
    GameObject Mikke;
    GameObject bolt;
    Component heroText;
    Component MikkeText;
    AudioSource audioSource;
    CinemachineVirtualCamera vcam;



    GameObject backgroundAmbient;
    [SerializeField][TextArea] string mikkeText1;
    [SerializeField][TextArea] string mikkeText2;
    [SerializeField][TextArea] string mikkeText3;
    [SerializeField][TextArea] string mikkeText4;

    void Start()
    {
        heroAnimator = GetComponent<Animator>();
        Mikke = GameObject.Find("Mikke");
        bolt = GameObject.Find("Bolt");
        vcam = GameObject.Find("Regular Camera").gameObject.GetComponent<CinemachineVirtualCamera>();
        backgroundAmbient = GameObject.Find("BackgroundAmbient");
        MikkeText = Mikke.gameObject.transform.Find("MikkeText");
        Mikke.gameObject.SetActive(false);
        bolt.gameObject.SetActive(false);
        heroText = gameObject.transform.Find("Text");
        hideHeroText();
        GlobalVariables.heroCanMove = false;
        audioSource = GetComponent<AudioSource>();
        if (GlobalVariables.platformLevelStarted)
        {
            FinishIt();
            backgroundAmbient.gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            Invoke("Speak0", 3f);
        }
    }

    void Speak0()
    {
        Invoke("Speak1", 1f);
    }

    void Speak1()
    {
        heroText.GetComponent<TextMesh>().text = "Where am I?";
        showHeroText();
        Invoke("Speak2", 3f);
    }
    void Speak2()
    {
        hideHeroText();
        Invoke("Speak3", 3f);
    }
    void Speak3()
    {
        heroText.GetComponent<TextMesh>().text = "Is this hell?";
        showHeroText();
        Invoke("Speak4", 3f);
    }

    void Speak4()
    {
        hideHeroText();
        Invoke("Speak5", 2f);
    }

    void Speak5()
    {
        MikkeText.GetComponent<TextMesh>().text = mikkeText1;
        Mikke.gameObject.SetActive(true);
        Invoke("Speak6", 7f);
    }

    void Speak6()
    {
        hideMikkeText();
        Invoke("Speak7", 1f);
    }
    void Speak7()
    {
        MikkeText.GetComponent<TextMesh>().text = mikkeText2;
        showMikkeText();
        Invoke("Speak8", 5f);
    }

    void Speak8()
    {
        hideMikkeText();
        Invoke("Speak9", 1f);
    }

    void Speak9()
    {
        heroAnimator.SetBool("isZoomed", true);
        Invoke("Speak10", 3f);
    }

    void Speak10()
    {
        MikkeText.GetComponent<TextMesh>().fontSize = 500;
        MikkeText.GetComponent<TextMesh>().text = mikkeText3;
        showMikkeText();
        audioSource.Play();
        backgroundAmbient.gameObject.GetComponent<AudioSource>().Play();
        bolt.gameObject.SetActive(true);
        Invoke("stopBolt", 1f);
        Invoke("Speak11", 8f);
    }

    void stopBolt()
    {
        bolt.gameObject.SetActive(false);
    }

    void Speak11()
    {
        hideMikkeText();
        Invoke("Speak12", 4f);
    }
    void Speak12()
    {
        MikkeText.GetComponent<TextMesh>().text = mikkeText4;
        showMikkeText();
        Invoke("Speak13", 7f);
    }

    void Speak13()
    {
        hideMikkeText();
        Invoke("Speak14", 1f);
    }

    void Speak14()
    {
        Mikke.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        Rigidbody2D mikkeBody = Mikke.gameObject.GetComponent<Rigidbody2D>();
        GlobalVariables.platformLevelStarted = true;
        mikkeBody.velocity = new Vector2(1f, 0.7f);
        Invoke("FinishIt", 5f);
    }

    void FinishIt()
    {
        Mikke.gameObject.SetActive(false);
        vcam.m_Lens.OrthographicSize = 5;
        heroAnimator.SetBool("isZoomed", false);
        GlobalVariables.heroCanMove = true;
        heroText.GetComponent<TextMesh>().fontSize = 500;
    }

    void showHeroText()
    {
        heroText.gameObject.SetActive(true);
    }
    void hideHeroText()
    {
        heroText.gameObject.SetActive(false);
    }

    void showMikkeText()
    {
        MikkeText.gameObject.SetActive(true);
    }
    void hideMikkeText()
    {
        MikkeText.gameObject.SetActive(false);
    }

}
