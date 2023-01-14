using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{

    void Start1()
    {
        Time.timeScale = 0f;
    }
    public void Retry1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Menu1()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
