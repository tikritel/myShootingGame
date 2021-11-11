//This is a score keeper. Decides if he player will win or loose as well. You can modify the player life from this script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class totalScores : MonoBehaviour
{
    public int deadBooks;
    private int totalEnemies;
    public int sucessPercentage;
    public int life;
    public Gameover gameOverScript;
    public WinScript winScript;

    private void Start()
    {
        totalEnemies = GameObject.Find("enemiesCreator").GetComponent<FlockingEffect>().numEnemies;
        life = 20;
    }

    void Update()
    {

        float calculatePercentage = (deadBooks / (float)totalEnemies) * 100;
        sucessPercentage = (int)(calculatePercentage);
        if (life == 0) gameOver();
        if (sucessPercentage == 100) winTheGame();

    }


    public void gameOver()
    {
        gameOverScript.setUp();
    }

    public void winTheGame()
    {
        winScript.winSetUp();
    }
    public void restartButton()
    {
        SceneManager.LoadScene("shootGame"); 
    }
}

