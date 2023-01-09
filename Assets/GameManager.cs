using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public Tower tower;

    public GameObject gameOverUI;

    void Update()
    {
        if (gameEnded)
            return;
        if (tower.health < 0)
        {
            EndGame();
        }
        //to toggle the game over screen for easier testing 

        //if (Input.GetKeyDown("e"))
        //{
        //    EndGame();
        //}
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
