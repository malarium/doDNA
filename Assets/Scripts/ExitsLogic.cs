using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitsLogic : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Initiate.Fade("Level0", Color.black, 1f);
        }
    }
}
