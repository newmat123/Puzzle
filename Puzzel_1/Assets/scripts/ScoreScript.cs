using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{

    float BestTime;
    float timeCount = 0;

    public bool gameactive;

    public Text TimerText;
    public Text record;
    public Text newrecord;
    public Text oldRecord;

    public GameObject GameHolder;
    public GameObject MenuHolder;
    public GameObject GameUI;
    public GameObject DeathUI;


    void Start()
    {

        DeathUI.SetActive(false);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        MenuHolder.SetActive(true);
        gameactive = false;

        BestTime = PlayerPrefs.GetFloat("savedRecord");
        
        oldRecord.text = BestTime.ToString("F2");

        
    }

    void Update()
    {

        if (gameactive == true)
        {

            timeCount += Time.deltaTime;

            TimerText.text = timeCount.ToString("F2");

        }

        if(gameactive==false && timeCount > 0)
        {

            if(timeCount > BestTime)
            {

                BestTime = timeCount;

                PlayerPrefs.SetFloat("savedRecord", timeCount);

                oldRecord.text = BestTime.ToString("F2");

                newrecord.text = "New Record!!";

            }

            record.text = timeCount.ToString("F2");

        }

    }

    public void startGame()
    {

        timeCount = 0f;

        GameHolder.SetActive(true);
        GameUI.SetActive(true);
        gameactive = true;
        MenuHolder.SetActive(false);

        FindObjectOfType<speedHolder>().Reset();
        FindObjectOfType<EnemySpawnScript>().startWaiter();

    }

    public void endGame()
    {

        DeathUI.SetActive(true);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        gameactive = false;

    }

    public void BackToStartMenu()
    {

        MenuHolder.SetActive(true);
        DeathUI.SetActive(false);

    }

}
