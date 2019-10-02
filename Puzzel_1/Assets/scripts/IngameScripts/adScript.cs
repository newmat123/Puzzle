using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adScript : MonoBehaviour
{

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

        rewardedAd = false;
        playAd = false;

        Advertisement.Initialize(store_id, true);
        timesPlayed = 0;
        
    }

    private void Update()
    {

        if (rewardedAd)
        {

            if(playAd == false)
            {

                timer += Time.fixedDeltaTime;
                if(timer >= 3)
                {

                    FindObjectOfType<ScoreScript>().endGame();
                    rewardedAd = false;
                    timer = 0;

                }

            }
            else
            {

                FindObjectOfType<ScoreScript>().continueGame();
                rewardedAd = false;
                timer = 0;
                playAd = false;
                   
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
        if(timesPlayed >= 4)
        {

            timesPlayed = 0;

            if (Advertisement.IsReady(video_ad))
            {

                Advertisement.Show(video_ad);

            }

        }

    }

}
