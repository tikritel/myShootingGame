
//The script will kill each book (with 3 shoots) and will increase the life of the player with each death. As the player is shooting the enemies  the books will get smaller so they will disapear
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class destroyEnemies : MonoBehaviour

{
    public int deadBooks;
    totalScores keepTheScoreScript;
    public Canvas mycanvas;


    private void Start()
    {
        keepTheScoreScript = GameObject.Find("ScoreHolder").GetComponent<totalScores>();

    }
    public void fightEnemies()

    {
        if (this.transform.localScale.x >= 0.25f)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, this.transform.localScale.z / 2);
        }
        else
        {
            Destroy(gameObject);
            keepTheScoreScript.deadBooks = keepTheScoreScript.deadBooks + 1;
            keepTheScoreScript.life = keepTheScoreScript.life + 1;

        }

    }
}
