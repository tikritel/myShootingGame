//The script make the gameOverCanvas active so the player can reset the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Text lifeText;
    public void setUp()
    {
        gameObject.SetActive(true);
        
    }
}
