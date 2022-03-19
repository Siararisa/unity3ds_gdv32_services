using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class AnalyticsSender : MonoBehaviour
{
    //very simple singleton
    public static  AnalyticsSender Instance;
    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void PressedStartButton()
    {
        Debug.Log("Adding pressedStartButton event");
        Analytics.CustomEvent("pressedStartButton");
    }

    public void CoinsCollectedPerLevel(int coins, int level)
    {
        Debug.Log("Adding coinsCollectedPerLevel event");
        Analytics.CustomEvent("coinsCollectedPerLevel", new Dictionary<string, object>
        {
            { "coins", coins },
            { "level", level }
        });
    }
}
