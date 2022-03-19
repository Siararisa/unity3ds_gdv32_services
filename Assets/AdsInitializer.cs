using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameId;
    [SerializeField] private string iosGameId;
    [SerializeField] private bool isTestMode = true;
    private string gameId;

    private void Awake()
    {
        Debug.Log("Initializing Unity Ads");
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer ? iosGameId : androidGameId);
        Advertisement.Initialize(gameId, isTestMode, this);
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log(string.Format("Unity Ads Initialization failed. Error: {0} = {1}", error.ToString(), message));
    }
}
