using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreScript : MonoBehaviour
{

    int SPuzzelPices = 0;
    int PuzzelPices = 0;
    int MissedPuzzelPices = 0;
    int money = 0;
    int totalMoney;


    int PriceSpecial = 20;
    int PriceNormal = 5;
    int PriceMissed = 5;


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
    public TextMeshProUGUI MissedPices;
    public TextMeshProUGUI TotalPriceText;
    public TextMeshProUGUI shopCash;

    [Space(20)]

    public GameObject GameHolder;
    public GameObject MenuHolder;
    public GameObject GameUI;
    public GameObject DeathUI;
    public GameObject CounterUI;
    public GameObject PauseMenu;
    public GameObject rewardedAdBottun;



    void Start()
    {

        rewardedAdBottun.SetActive(false);
        PauseMenu.SetActive(false);
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


    public void missedOne()
    {
        MissedPuzzelPices += 1;
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

        money = ((PuzzelPices * PriceNormal) + (SPuzzelPices * PriceSpecial)) - (MissedPuzzelPices * PriceMissed);

        if(money < 0)
        {
            money = 0;
        }

        totalMoney += money;
        GemCash(totalMoney);

    }



    public void startGame()
    {

        FindObjectOfType<SettingsAnimScript>().settings(false);
        FindObjectOfType<shopAnimScript>().openShop(false);

        CounterUI.SetActive(true);
        MenuHolder.SetActive(false);

        FindObjectOfType<SoundManeger>().unDampeSound();
        FindObjectOfType<SoundManeger>().HitSFX("b");
    }

    public void afterCount()
    {

        FindObjectOfType<BagGroundScript>().fadeBagground(true);

        timeCount = 0f;

        CounterUI.SetActive(false);
        GameHolder.SetActive(true);
        GameUI.SetActive(true);
        gameactive = true;

        FindObjectOfType<speedHolder>().Reset();
        FindObjectOfType<EnemySpawnScript>().startWaiter();
        FindObjectOfType<slowMotion>().Start();

    }


    
    public void pauseGame()
    {
        if (!rewardedAdBottun.activeInHierarchy)
        {
            FindObjectOfType<BagGroundScript>().fadeBagground(false);
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            FindObjectOfType<SoundManeger>().HitSFX("b");
        }
        else
        {
            PauseMenu.SetActive(false);
        }

    }

    public void unPauseGame()
    {

        FindObjectOfType<BagGroundScript>().fadeBagground(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<SoundManeger>().HitSFX("b");

    }

    public void beforeEnding()
    {
        FindObjectOfType<BagGroundScript>().fadeBagground(false);
        Time.timeScale = 0;

        rewardedAdBottun.SetActive(true);
        
        FindObjectOfType<adScript>().rewardedAd = true;

    }

    public void continueGame()
    {

        FindObjectOfType<BagGroundScript>().fadeBagground(true);
        Time.timeScale = 1;

        rewardedAdBottun.SetActive(false);


    }

    public void endGame()
    {
        FindObjectOfType<BagGroundScript>().fadeBagground(false);
        FindObjectOfType<HealtBar>().fullHealth();
        CalMoney();

        NormalPizzesText.text = PuzzelPices.ToString();
        SpecialPizzesText.text = SPuzzelPices.ToString();
        MissedPices.text = MissedPuzzelPices.ToString();
        TotalPriceText.text = money.ToString();

        Time.timeScale = 1;

        DeathUI.SetActive(true);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        PauseMenu.SetActive(false);
        rewardedAdBottun.SetActive(false);
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
        MissedPuzzelPices = 0;
        newrecord.text = "";

        MenuHolder.SetActive(true);
        DeathUI.SetActive(false);
        FindObjectOfType<SettingsAnimScript>().settings(false);
        FindObjectOfType<shopAnimScript>().openShop(false);
        FindObjectOfType<SoundManeger>().HitSFX("b");
    }

    public void settings()
    {

        FindObjectOfType<SettingsAnimScript>().settings(true);
        FindObjectOfType<shopAnimScript>().openShop(false);
        FindObjectOfType<SoundManeger>().HitSFX("b");

    }

    public void ShopBottun()
    {

        FindObjectOfType<Shop>().updateShop();
        updateText();

        FindObjectOfType<shopAnimScript>().openShop(true);
        FindObjectOfType<SettingsAnimScript>().settings(false);
        FindObjectOfType<SoundManeger>().HitSFX("b");

    }

}
