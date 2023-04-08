using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D ballBody;

    void Start()
    {
        ballBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyGoalArea" && PointsLogic.timeRemaining > 0)

        {
            PointsLogic.PlayerPoints++;
        }
        if (other.tag == "PlayerGoalArea" && PointsLogic.timeRemaining > 0)
        {
            PointsLogic.EnemyPoints++;
        }
    }
}
