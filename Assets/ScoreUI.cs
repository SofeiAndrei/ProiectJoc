using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;
    private static int killedAnEnemy = 0;
    private static int scoreGained = 0;
    public BadGuy enemy;
    private float countdown = 1f;

    // Update is called once per frame
    void Update()
    {
        if (killedAnEnemy == 1)
        {
            scoreText.text = Score.score.ToString() + " +" + scoreGained.ToString();
            if (countdown <= 0f)
            {
                killedAnEnemy = 0;
                countdown = 1f;
            }
            countdown -= Time.deltaTime;
        }
        else
        {
            scoreText.text = Score.score.ToString();
        }
   
    }
    public void KilledEnemies(int _scoreGained)
    {
        killedAnEnemy = 1;
        scoreGained = _scoreGained;
    }
}
