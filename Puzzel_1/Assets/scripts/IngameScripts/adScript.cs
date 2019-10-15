using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adScript : MonoBehaviour
{

    public bool isAdPlayed;
    public bool playAd;
    public bool rewardedAd;

    private float timer;
    private int timesPlayed;


    void Start()
    {

        isAdPlayed = false;
        rewardedAd = false;
        playAd = false;

        timesPlayed = 0;
        
    }

    private void Update()
    {
        if (rewardedAd)
        {
            if (isAdPlayed == false)
            {
                if (playAd == false)
                {
                    timer += Time.fixedDeltaTime;
                    if (timer >= 4f)
                    {
                        FindObjectOfType<ScoreScript>().endGame();
                        rewardedAd = false;
                        timer = 0f;
                    }
                }
                else
                {
                    if (Advertisement.IsReady("rewardedVideo"))
                    {
                        UnityADS.Instance.showRewardedAd(OnRewardedAdClosed);
                    }
                    else
                    {
                        FindObjectOfType<ScoreScript>().endGame();
                        rewardedAd = false;
                        playAd = false;
                        timer = 0f;
                    }
                }
            }
        }
    }

    public void clkRewardedAd()
    {
        timer = 0f;
        playAd = true;
    }

    public void playedOne()
    {
        timesPlayed++;
        if(timesPlayed >= 3f)
        {
            timesPlayed = 0;
            UnityADS.Instance.showRegularAd(onAdClosed);
        }
    }


    private void onAdClosed(ShowResult result)
    {

    }
    private void OnRewardedAdClosed(ShowResult result)
    {

        switch (result)
        {

            case ShowResult.Finished:
                FindObjectOfType<HealtBar>().fullHealth();
                FindObjectOfType<ScoreScript>().continueGame();
                playAd = false;
                rewardedAd = false;
                isAdPlayed = true;
                timesPlayed = 0;
                timer = 0;
                break;

            case ShowResult.Skipped:
                FindObjectOfType<HealtBar>().fullHealth();
                FindObjectOfType<ScoreScript>().continueGame();
                playAd = false;
                rewardedAd = false;
                isAdPlayed = true;
                timesPlayed = 0;
                timer = 0;
                break;

            case ShowResult.Failed:
                FindObjectOfType<HealtBar>().fullHealth();
                FindObjectOfType<ScoreScript>().continueGame();
                playAd = false;
                rewardedAd = false;
                isAdPlayed = true;
                timesPlayed = 0;
                timer = 0;
                break;

        }
    }
}
