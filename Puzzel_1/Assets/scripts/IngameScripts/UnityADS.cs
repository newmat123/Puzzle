using System;
using UnityEngine;

#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UnityADS : MonoBehaviour
{
    #region Instance
    private static UnityADS instance;
    public static UnityADS Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UnityADS>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned UnityADS", typeof(UnityADS)).GetComponent<UnityADS>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Config")]
    [SerializeField] private string gameID = "";
    [SerializeField] private bool testMode = true;
    [SerializeField] private string rewardedVideoPlacementId;
    [SerializeField] private string regularPlacementId;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Advertisement.Initialize(gameID, testMode);
    }

    public void showRegularAd(Action<ShowResult> callback)
    {
#if UNITY_ADS 
        if (Advertisement.IsReady(regularPlacementId))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = callback;
            Advertisement.Show(regularPlacementId, so);
        }
#endif
    }
    public void showRewardedAd(Action<ShowResult> callback)
    {
#if UNITY_ADS
        if (Advertisement.IsReady(rewardedVideoPlacementId))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = callback;
            Advertisement.Show(rewardedVideoPlacementId, so);
        }
#endif
    }
}