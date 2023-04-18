using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    [SerializeField] float timeBeforeDestroyed = 1f;
    void Start()
    {
        Invoke("killObject", timeBeforeDestroyed);
    }

    void killObject()
    {
        Destroy(gameObject);
    }
}
