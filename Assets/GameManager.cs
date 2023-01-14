using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public Tower tower;
    public EnemyTowerScript enemyTower;
    public Transform start;
    public Player player;
    Vector3 enemyRuinsPos = new Vector3(-69, 2, 30);

    public GameObject gameOverUI;
    public GameObject gameWonUI;
    public Transform towerRuins;

    void Update()
    {
        if (gameEnded)
            return;
        if (tower.health <= 0 || player.health <= 0 )
        {
            Instantiate(towerRuins, towerRuins.position, towerRuins.rotation);
            EndGame();
        }

        if (enemyTower.health <= 0)
        {
            Instantiate(towerRuins, enemyRuinsPos, Quaternion.Euler(0f, 0f, 0f));
            Victory();
        }
        //to toggle the game over screen for easier testing 

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);   
        AudioManager.Instance.PlaySFX("lose");
    }

    void Victory()
    {
        gameEnded = true;
        gameWonUI.SetActive(true);
        AudioManager.Instance.PlaySFX("win");
    }
}
