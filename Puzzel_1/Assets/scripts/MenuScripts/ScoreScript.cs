using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreScript : MonoBehaviour
{

    int SPuzzelPices = 0;
    int PuzzelPices = 0;
    int money = 0;
    int totalMoney;




    int PriceSpecial = 20;
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
    public TextMeshProUGUI SpecialPizzesText;
    public TextMeshProUGUI TotalPriceText;
    public TextMeshProUGUI shopCash;

    [Space(20)]

    public GameObject GameHolder;
    public GameObject MenuHolder;
    public GameObject GameUI;
    public GameObject DeathUI;
    public GameObject CounterUI;
    public GameObject SettingsMenu;
    public GameObject Shop;
    public GameObject PauseMenu;



    void Start()
    {

        PauseMenu.SetActive(false);
        Shop.SetActive(false);
        SettingsMenu.SetActive(false);
        CounterUI.SetActive(false);
        DeathUI.SetActive(false);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        MenuHolder.SetActive(true);
        gameactive = false;

        BestTime = PlayerPrefs.GetFloat("savedRecord");

        updateText();
        FindObjectOfType<Shop>().updateShop();

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

    public void PlusOneSpecial()
    {
        SPuzzelPices += 1;
    }


    public void GemCash(int cash)
    {
        PlayerPrefs.SetInt("myCash", cash);
    }




    public void CalMoney()
    {

        money = (PuzzelPices * PriceNormal) + (SPuzzelPices * PriceSpecial);
        totalMoney += money;
        GemCash(totalMoney);

    }



    public void startGame()
    {

        CounterUI.SetActive(true);
        MenuHolder.SetActive(false);

        FindObjectOfType<SoundManeger>().unDampeSound();

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
        FindObjectOfType<slowMotion>().Start();

    }

    public void beforeEnding()
    {
        //se ad for at fortsætte
    }
    
    public void pauseGame()
    {

        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        
    }

    public void unPauseGame()
    {

        PauseMenu.SetActive(false);
        Time.timeScale = 1;
       
    }


    public void endGame()
    {

        CalMoney();

        NormalPizzesText.text = PuzzelPices.ToString();
        SpecialPizzesText.text = SPuzzelPices.ToString();
        TotalPriceText.text = money.ToString();

        Time.timeScale = 1;

        DeathUI.SetActive(true);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        PauseMenu.SetActive(false);
        gameactive = false;

        FindObjectOfType<adScript>().playedOne();
        FindObjectOfType<SoundManeger>().dampeSound();

    }


    public void updateText()
    {
        totalMoney = PlayerPrefs.GetInt("myCash");
        shopCash.text = totalMoney.ToString();
    }


    public void BackToStartMenu()
    {

        SPuzzelPices = 0;
        PuzzelPices = 0;
        newrecord.text = "";

        MenuHolder.SetActive(true);
        DeathUI.SetActive(false);
        SettingsMenu.SetActive(false);
        Shop.SetActive(false);

    }

    public void settings()
    {

        SettingsMenu.SetActive(true);
        MenuHolder.SetActive(false);

    }

    public void ShopBottun()
    {

        FindObjectOfType<Shop>().updateShop();

        Shop.SetActive(true);
        MenuHolder.SetActive(false);

    }

}
