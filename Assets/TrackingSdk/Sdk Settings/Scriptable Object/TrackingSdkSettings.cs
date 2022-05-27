using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Resources/TrackingSdk/TrackingSdkSettings", menuName = "Tracking Sdk/Settings")]
public class TrackingSdkSettings : ScriptableObject
{
    [Header("Game Analytics IOS")]
    [Tooltip("Your GameAnalytics Ios Game Key")]
    public string gameAnalyticsIosGameKey;
    [Tooltip("Your GameAnalytics Ios Secret Key")]
    public string gameAnalyticsIosSecretKey;
    
    
    [Header("Game Analytics Android")]
    [Tooltip("Your GameAnalytics Android Game Key")]
    public string gameAnalyticsAndroidGameKey;
    [Tooltip("Your GameAnalytics Android Secret Key")]
    public string gameAnalyticsAndroidSecretKey;
    
    
    [Header("Facebook")]
    [Tooltip("The Facebook App Id of your game")]
    public string facebookAppId;
    
    private const string Settings_Path = "TrackingSdk/Settings";

    public static TrackingSdkSettings Load() => Resources.Load<TrackingSdkSettings>(Settings_Path);
    
}
