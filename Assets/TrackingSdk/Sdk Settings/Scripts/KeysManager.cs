using System.Collections;
using System.Collections.Generic;
using Facebook.Unity.Settings;
using GameAnalyticsSDK;
using UnityEditor;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    public static void SetGAKeys(TrackingSdkSettings settings)
    {
#if UNITY_ANDROID
        UpdateGASettings(settings.gameAnalyticsAndroidGameKey, settings.gameAnalyticsAndroidSecretKey,
            RuntimePlatform.Android);


#elif UNITY_IOS
UpdateGASettings(settings.gameAnalyticsIosGameKey, settings.gameAnalyticsIosSecretKey,
            RuntimePlatform.IPhonePlayer);
#endif
    }


    private static void  UpdateGASettings(string gameKey, string secretKey, RuntimePlatform platform)
    {
        if (string.IsNullOrEmpty(gameKey) || string.IsNullOrEmpty(secretKey))
        {
            Debug.LogError("Game Analytics Keys are Missing ");
            return;
        }


        if (!GameAnalytics.SettingsGA.Platforms.Contains(platform))
            GameAnalytics.SettingsGA.AddPlatform(platform);

        int platformIndex = GameAnalytics.SettingsGA.Platforms.IndexOf(platform);
        GameAnalytics.SettingsGA.UpdateGameKey(platformIndex, gameKey);
        GameAnalytics.SettingsGA.UpdateSecretKey(platformIndex, secretKey);
        GameAnalytics.SettingsGA.Build[platformIndex] = Application.version;
        GameAnalytics.SettingsGA.InfoLogBuild = false;
        GameAnalytics.SettingsGA.InfoLogEditor = false;
        return;
    }

    public static void SetFBKeys(TrackingSdkSettings settings)
    {
#if UNITY_ANDROID || UNITY_IOS

        if (settings == null || string.IsNullOrEmpty(settings.facebookAppId))
        {
            Debug.LogError("Facebook Keys are Missing ");
        }


        else
        {
            FacebookSettings.AppIds = new List<string> { settings.facebookAppId };
            FacebookSettings.AppLabels = new List<string> { Application.productName };
            //  EditorUtility.SetDirty(FacebookSettings.Instance);
        }
#endif
    }
}