using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class adScript : MonoBehaviour
{

    int timesPlayed;

    private string store_id = "3312267";

    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    private string banner_ad = "bannerAd";

    void Start()
    {

        Monetization.Initialize(store_id, true);
        timesPlayed = 0;
        
    }


    public void playedOne()
    {
        timesPlayed++;
        if(timesPlayed >= 4)
        {

            timesPlayed = 0;

            if (Monetization.IsReady(video_ad))
            {

                ShowAdPlacementContent ad = null;

                ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

                if(ad != null)
                {
                    ad.Show();
                }

            }

        }

    }

}
