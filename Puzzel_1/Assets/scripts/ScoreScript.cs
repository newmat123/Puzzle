﻿using System.Collections;
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

    public GameObject GameHolder;
    public GameObject MenuHolder;
    public GameObject GameUI;

    void Start()
    {

        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        gameactive = false;
        BestTime = PlayerPrefs.GetFloat("savedRecord");

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

                //newrecord.text = "New Record!!";

            }

            //record.text = timeCount.ToString();

        }

    }

    public void startGame()
    {

        GameHolder.SetActive(true);
        GameUI.SetActive(true);
        gameactive = true;
        MenuHolder.SetActive(false);

        FindObjectOfType<EnemySpawnScript>().startWaiter();

    }

    public void endGame()
    {

        MenuHolder.SetActive(true);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        gameactive = false;

    }

}
