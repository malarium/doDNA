using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDownSpriteMovement : MonoBehaviour
{
    Transform transformComponent;
    float randomTime;
    void Start()
    {
        transformComponent = GetComponent<Transform>();
        randomTime = Random.Range(0.3f, 0.5f);
        moveDown();
    }

    void moveUp()
    {
        transformComponent.position = new Vector3(transformComponent.position.x, transformComponent.position.y - 0.025f, transformComponent.position.z);
        Invoke("moveDown", randomTime);
    }
    void moveDown()
    {
        transformComponent.position = new Vector3(transformComponent.position.x, transformComponent.position.y + 0.025f, transformComponent.position.z);
        Invoke("moveUp", randomTime);
    }
}
