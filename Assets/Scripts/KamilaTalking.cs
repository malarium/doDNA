using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class KamilaTalking : MonoBehaviour
{
    Component textObject;
    GameObject ola;
    WalkAutomatically olaWalkScript;
    [SerializeField][TextArea] string noFoosballWon;
    [SerializeField][TextArea] string noCupBrought;
    [SerializeField][TextArea] string allDone;
    Light2D myLight;
    void Start()
    {
        textObject = gameObject.transform.Find("KamilaText");
        ola = GameObject.Find("Ola");
        olaWalkScript = ola.GetComponent<WalkAutomatically>();
        myLight = gameObject.transform.Find("myLight").GetComponent<Light2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalVariables.heroCanMove = false;
            stopOla();
            textObject.gameObject.SetActive(false);
            bool foosballWon = PlayerPrefs.HasKey("won");
            if (!foosballWon)
            {
                textObject.GetComponent<TextMesh>().text = noFoosballWon;
                GlobalVariables.heroCanMove = true;
            }
            else if (!GlobalVariablesKitchen.kitchenQuestFinished)
            {
                textObject.GetComponent<TextMesh>().text = noCupBrought;
                GlobalVariables.heroCanMove = true;
            }
            else
            {
                textObject.GetComponent<TextMesh>().text = allDone;
                Invoke("runFadeEffect", 2f);
                Invoke("goToSweden", 4f);
            }
            textObject.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.gameObject.SetActive(false);
            olaWalkScript.enabled = true;
        }
    }

    void runFadeEffect()
    {
        StartCoroutine(FadeHero());
    }

    IEnumerator FadeHero()
    {
        float i = myLight.intensity;
        for (float intensity = 1f; intensity <= 12; intensity += 0.2f)
        {
            i = intensity;
            myLight.intensity = i;
            yield return new WaitForSeconds(.01f);
        }
    }
    void goToSweden()
    {
        Initiate.Fade("Level3", Color.black, 1f);
    }
    void stopOla()
    {
        olaWalkScript.enabled = false;
        ola.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}