using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreHolder : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private int maxAmountOfScores = 7;

    private void Awake()
    {
        
        entryContainer = transform.Find("ScoreContainer");
        entryTemplate = entryContainer.Find("ScoreTemplet");

        entryTemplate.gameObject.SetActive(false);

        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //sort entry list by score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for(int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    //swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        
        while(highscores.highscoreEntryList.Count > maxAmountOfScores)
        {
            highscores.highscoreEntryList.RemoveAt(highscores.highscoreEntryList.Count - 1);
        }
            
        
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
        
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHight = 118f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("placeText").GetComponent<TextMeshProUGUI>().text = rankString;

        //------------------------------------------------
        float score = highscoreEntry.score;

        entryTransform.Find("timeText").GetComponent<TextMeshProUGUI>().text = score.ToString("F2");

        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        entryTransform.Find("ScoreBagground").gameObject.SetActive(rank % 2 == 1);

        if(rank == 1)
        {
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("timeText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("placeText").GetComponent<TextMeshProUGUI>().color = Color.green;
        }

        switch (rank)
        {
            default:
                entryTransform.Find("star").gameObject.SetActive(false);
                break;
            case 1:
                entryTransform.Find("star").GetComponent<Image>().color = Color.magenta;
                break;
            case 2:
                entryTransform.Find("star").GetComponent<Image>().color = Color.grey;
                break;
            case 3:
                entryTransform.Find("star").GetComponent<Image>().color = Color.black;
                break;
        }

        transformList.Add(entryTransform);
    }




    public void AddHighscoreEntry(float score, string name)
    {
        //Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //load saved list
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //adds new highscore
        
        highscores.highscoreEntryList.Add(highscoreEntry);
        

        //saves new list
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

        Awake();

    }


    //test
    public void rrr()
    {

        AddHighscoreEntry(0, "none");

    }


    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    // a singel high score entry
    [System.Serializable]
    private class HighscoreEntry
    {
        public float score;
        public string name;
    }

}
