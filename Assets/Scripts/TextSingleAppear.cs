using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSingleAppear : MonoBehaviour
{
    Component textObject;
    [SerializeField][TextArea] string NPCtext;
    void Start()
    {
        textObject = GetComponentInChildren<TextMesh>();
        textObject.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            textObject.GetComponent<TextMesh>().text = NPCtext;

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
