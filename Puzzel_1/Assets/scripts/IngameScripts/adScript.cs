using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adScript : MonoBehaviour
{

    public bool isAdPlayed;
    public bool rewardedAd;
    public bool playAd;

    float timer;

    int timesPlayed;

    private string store_id = "3312267";

    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    private string banner_ad = "bannerAd";

    void Start()
    {

        isAdPlayed = false;
        rewardedAd = false;
        playAd = false;

        Advertisement.Initialize(store_id);
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

                    if (Advertisement.IsReady(rewarded_video_ad))
                    {

                        Advertisement.Show(rewarded_video_ad, new ShowOptions() { resultCallback = HandleAdResult });
                        

                    }

                }
            }
            
        }

    }

    public void clkRewardedAd()
    {
        playAd = true;
    }

    public void playedOne()
    {
        timesPlayed++;
        if(timesPlayed >= 3f)
        {

            timesPlayed = 0;

            if (Advertisement.IsReady(video_ad))
            {

                Advertisement.Show(video_ad);

            }

        }

    }

    private void HandleAdResult(ShowResult result)
    {

        switch (result)
        {

            case ShowResult.Finished:
                FindObjectOfType<HealtBar>().fullHealth();
                FindObjectOfType<ScoreScript>().continueGame();
                playAd = false;
                rewardedAd = false;
                isAdPlayed = true;
                timer = 0f;
                break;

            case ShowResult.Skipped:
                FindObjectOfType<ScoreScript>().endGame();
                playAd = false;
                rewardedAd = false;
                isAdPlayed = false;
                timer = 0f;
                break;

            case ShowResult.Failed:
                FindObjectOfType<ScoreScript>().endGame();
                playAd = false;
                rewardedAd = false;
                isAdPlayed = false;
                timer = 0f;
                break;

        }

    }

}
