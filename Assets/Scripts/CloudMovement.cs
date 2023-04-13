using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    [SerializeField] float cloudSpeed = 0.001f;

    void Update()
    {
        transform.position += new Vector3(cloudSpeed, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "cloudLimiter" || other.name == "cloudLimiter_2")
        {
            cloudSpeed = -cloudSpeed;
        }
    }
}
