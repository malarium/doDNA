using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFoosballOponent : MonoBehaviour
{
    Component textObject;
    [SerializeField][TextArea] string NPCtextFirstGame;
    [SerializeField][TextArea] string NPCtextAnotherGame;
    int best = 0;
    void Start()
    {
        textObject = GetComponentInChildren<TextMesh>();
        textObject.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("best"))
        {
            best = PlayerPrefs.GetInt("best");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalVariables.heroCanMove = false;
            if (best == 0)
            {
                textObject.GetComponent<TextMesh>().text = NPCtextFirstGame;

            }
            else if (best > 0)
            {
                textObject.GetComponent<TextMesh>().text =
                "Your best score was " + best.ToString() + "." + NPCtextAnotherGame;
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
}
