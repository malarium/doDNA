using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFoosball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("playFoosball", 4f);
        }
    }

    void playFoosball()
    {
        Initiate.Fade("Level2", Color.black, 3f);
    }
}
