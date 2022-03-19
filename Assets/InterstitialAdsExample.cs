using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdsExample : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;
    private string adUnitId;

    public void LoadAd()
    {
        Debug.Log("Loading Interstitial Ads..");
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer ? iosAdUnitId : androidAdUnitId);
        //You must only Load an Ad AFTER initializing the Unity Ads.
        Advertisement.Load(adUnitId, this);
    }

    public void ShowAd()
    {
        //If you haven't properly loaded an AD, this will fail
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial Ads successfully loaded");
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log(string.Format("Interstitial Ads failed to load.  Error: {0} = {1}", error.ToString(), message));
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        //Load the next level after viewing the ad
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log(string.Format("Failed to show Ad.  Error: {0} = {1}", error.ToString(), message));
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Showing Interstitial Ad...");
    }
}
