//The script is reducing the life of the player depending on how many times the enemies hit the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
    totalScores keepTheScoreScript;

    private void Start()
    {
        keepTheScoreScript = GameObject.Find("ScoreHolder").GetComponent<totalScores>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            keepTheScoreScript.life = keepTheScoreScript.life - 1; //each hit by the book will reduce 1 point the life of the player
        }
    }
}
