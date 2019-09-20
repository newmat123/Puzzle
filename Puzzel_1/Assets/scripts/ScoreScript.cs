using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreScript : MonoBehaviour
{

    int PuzzelPices = 0;
    int money = 0;
    int totalMoney;

    int PriceNormal = 5;

    float BestTime;
    float timeCount = 0;

    [Space(20)]

    public bool gameactive;

    [Space(20)]

    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI record;
    public TextMeshProUGUI newrecord;
    public TextMeshProUGUI oldRecord;

    [Space(20)]

    public TextMeshProUGUI NormalPizzesText;
    public TextMeshProUGUI TotalPriceText;

    [Space(20)]

    public GameObject GameHolder;
    public GameObject MenuHolder;
    public GameObject GameUI;
    public GameObject DeathUI;
    public GameObject CounterUI;



    void Start()
    {

        CounterUI.SetActive(false);
        DeathUI.SetActive(false);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        MenuHolder.SetActive(true);
        gameactive = false;

        BestTime = PlayerPrefs.GetFloat("savedRecord");
        totalMoney = PlayerPrefs.GetInt("myCash");

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



    public void PlusOne()
    {

        PuzzelPices += 1;

    }




    public void GemCash(int cash)
    {
        PlayerPrefs.SetInt("myCash", cash);
    }




    public void CalMoney()
    {

        money = (PuzzelPices * PriceNormal);
        totalMoney += money;
        GemCash(totalMoney);

    }



    public void startGame()
    {

        CounterUI.SetActive(true);
        MenuHolder.SetActive(false);

    }

    public void afterCount()
    {

        timeCount = 0f;

        CounterUI.SetActive(false);
        GameHolder.SetActive(true);
        GameUI.SetActive(true);
        gameactive = true;

        FindObjectOfType<speedHolder>().Reset();
        FindObjectOfType<EnemySpawnScript>().startWaiter();
    }



    public void endGame()
    {

        CalMoney();

        NormalPizzesText.text = PuzzelPices.ToString();
        TotalPriceText.text = money.ToString();

        DeathUI.SetActive(true);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        gameactive = false;

    }





    public void BackToStartMenu()
    {

        PuzzelPices = 0;
        newrecord.text = "";

        MenuHolder.SetActive(true);
        DeathUI.SetActive(false);

    }

}
