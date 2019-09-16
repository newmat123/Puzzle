using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{

    string oldtext;
    float BestTime;
    float timeCount = 0;
    int multiplayer;

    public bool gameactive;

    public Text TimerText;
    public Text record;
    public Text newrecord;
    public Text oldRecord;

    public GameObject GameHolder;
    public GameObject MenuHolder;
    public GameObject GameUI;
    public GameObject DeathUI;

    public GameObject inGameClock;
    public GameObject inDeathClock;
    public GameObject MainMenuClock;

    void Start()
    {

        DeathUI.SetActive(false);
        GameHolder.SetActive(false);
        GameUI.SetActive(false);
        MenuHolder.SetActive(true);
        gameactive = false;

        BestTime = PlayerPrefs.GetFloat("savedRecord");
        
        oldRecord.text = BestTime.ToString("F2");

        if(BestTime.ToString().Length > 0)
        {

            multiplayer = BestTime.ToString().Length;

        }
        else
        {

            multiplayer = 1;

        }
        
        MainMenuClock.transform.position = new Vector3(MainMenuClock.transform.position.x - 28 * multiplayer, MainMenuClock.transform.position.y, MainMenuClock.transform.position.z);

    }

    void Update()
    {

        if (gameactive == true)
        {
            oldtext = timeCount.ToString("F2");
            timeCount += Time.deltaTime;

            TimerText.text = timeCount.ToString("F2");

            if(TimerText.text.Length > oldtext.Length)
            {

                inGameClock.transform.position = new Vector3(inGameClock.transform.position.x - 28, inGameClock.transform.position.y, inGameClock.transform.position.z);
                inDeathClock.transform.position = new Vector3(inDeathClock.transform.position.x - 28, inDeathClock.transform.position.y, inDeathClock.transform.position.z);

            }
           
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
