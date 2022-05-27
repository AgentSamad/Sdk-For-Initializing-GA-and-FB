using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

public class InitializeABTest : MonoBehaviour
{
    private void Start()
    {
        Init();
    }


    private void Init()
    {
        AbTest test = Resources.Load("TrackingSdk/AbTestInfo") as AbTest;
        if (!PlayerPrefs.HasKey("CheckOnce"))
        {
            PlayerPrefs.SetInt("CheckOnce", 1);
            test.UpdateCurrentVersion();
            GameAnalytics.NewDesignEvent("build : " + test.GetCurrentVairent());
        }

        Destroy(this.gameObject);
    }
}