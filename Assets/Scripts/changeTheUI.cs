//The script is changing the text score in the UI depending on the values at totalScoresScript

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class changeTheUI : MonoBehaviour
{
    totalScores scoreScript;
    int life;
    Text scoreLife;
    Text scoreSuccess;
    double actualScore;
    void Start()
    {

        scoreScript = GameObject.Find("ScoreHolder").GetComponent<totalScores>();
        scoreLife = GameObject.Find("Canvas/Life").GetComponent<Text>();
        scoreSuccess = GameObject.Find("Canvas/Success").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        actualScore = scoreScript.sucessPercentage;
        scoreLife.text = "Sucess " + actualScore + "%";
        actualScore = scoreScript.sucessPercentage;
        life = scoreScript.life;
        scoreSuccess.text = "Success  " + actualScore + "%";
        scoreLife.text = "Life  " + life;

    }
}
