using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputScript : MonoBehaviour
{
    public GameObject inputField;
    public GameObject highScore;

    HighScoreScript highScoreScript;

    //HighScoreScript highScoreScript;
    public string playerName;
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            playerName = inputField.GetComponent<TMP_InputField>().text;
            Debug.Log(playerName);
            highScoreScript = highScore.GetComponent<HighScoreScript>();
            highScoreScript.AddHighScoreEntry(Score.score, playerName);
        }

    }

}

