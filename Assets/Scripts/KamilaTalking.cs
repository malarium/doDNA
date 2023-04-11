using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamilaTalking : MonoBehaviour
{
    Component textObject;
    [SerializeField][TextArea] string noFoosballWon;
    [SerializeField][TextArea] string noCupBrought;
    [SerializeField][TextArea] string allDone;
    void Start()
    {
        textObject = gameObject.transform.Find("KamilaText");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.gameObject.SetActive(false);
            bool foosballWon = PlayerPrefs.HasKey("won");

            if (!foosballWon)
            {
                textObject.GetComponent<TextMesh>().text = noFoosballWon;
            }
            else if (!GlobalVariablesKitchen.kitchenQuestFinished)
            {
                textObject.GetComponent<TextMesh>().text = noCupBrought;
            }
            else
            {
                GlobalVariables.heroCanMove = false;
                textObject.GetComponent<TextMesh>().text = allDone;
                StartCoroutine(FadeHero(other.gameObject));
            }
            textObject.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.gameObject.SetActive(false);
        }
    }


    IEnumerator FadeHero(GameObject hero)
    {
        Renderer renderer = hero.GetComponent<Renderer>();
        Color c = renderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(.25f);
        }
    }
}