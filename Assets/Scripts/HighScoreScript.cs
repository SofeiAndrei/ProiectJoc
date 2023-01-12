using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        if (entryContainer != null)
        {
            entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

            entryTemplate.gameObject.SetActive(false);

            string jsonString = PlayerPrefs.GetString("highscoreTable", "");
            if (jsonString == "")
            {
                highScoreEntryList = new List<HighScoreEntry>()
                {
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                    new HighScoreEntry{ score = 0, name = "NONE"},
                };

                highScoreEntryTransformList = new List<Transform>();
                foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
                {
                    CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
                }

                string json = JsonUtility.ToJson(highScoreEntryList);
                PlayerPrefs.SetString("highscoreTable", json);
                PlayerPrefs.Save();
                Debug.Log(PlayerPrefs.GetString("highscoreTable"));
            }
            else
            {
                HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
                highScoreEntryList = highScores.highScoreEntryList;
                //Sorting the entries
                for (int i = 0; i < highScoreEntryList.Count; i++)
                {
                    for (int j = i + 1; j < highScoreEntryList.Count; j++)
                    {
                        if (highScoreEntryList[j].score > highScoreEntryList[i].score)
                        {
                            HighScoreEntry temp = highScoreEntryList[j];
                            highScoreEntryList[j] = highScoreEntryList[i];
                            highScoreEntryList[i] = temp;
                        }
                    }
                }

                highScoreEntryTransformList = new List<Transform>();
                foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
                {
                    CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
                }
            }
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 20f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
            case 1: {
                rankString = "1ST";
                break;
            }
            case 2: {
                rankString = "2ND";
                break;
            }
            case 3: {
                rankString = "3RD";
                break;
            }
            default: {
                rankString = rank + "TH";
                break;
            }
        }
        entryTransform.Find("RankText").GetComponent<Text>().text = rankString;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = highscoreEntry.score.ToString();
        entryTransform.Find("NameText").GetComponent<Text>().text = highscoreEntry.name;

        transformList.Add(entryTransform);
    }

    public void AddHighScoreEntry(int score, string name)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        //Load HighScores
        string jsonString = PlayerPrefs.GetString("highscoreTable", "");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        highScoreEntryList = highScores.highScoreEntryList;
        if(highScoreEntryList.Count >= 10) 
        {
            //Check if the leaderboard is full and the current score is higher than the lowest score on the leaderboard to replace it
            //Sorting the entries
            for (int i = 0; i < highScoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highScoreEntryList.Count; j++)
                {
                    if (highScoreEntryList[j].score > highScoreEntryList[i].score)
                    {
                        HighScoreEntry temp = highScoreEntryList[j];
                        highScoreEntryList[j] = highScoreEntryList[i];
                        highScoreEntryList[i] = temp;
                    }
                }
            }

            if(score > highScoreEntryList[highScoreEntryList.Count - 1].score)
            {
                highScoreEntryList[highScoreEntryList.Count - 1].score = score;
                highScoreEntryList[highScoreEntryList.Count - 1].name = name;
            }
        }
        else
        {
            //Add New HighScore
            highScores.highScoreEntryList.Add(highScoreEntry);
        }

        //Save HighScores
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class HighScores {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry 
    {
        public int score;
        public string name;
    }
}
