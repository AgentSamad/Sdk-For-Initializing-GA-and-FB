using Facebook.Unity;
using GameAnalyticsSDK;
using UnityEditor;
using UnityEngine;

public class TrackingSdkManager : MonoBehaviour
{
    private static TrackingSdkManager instance;


    private void Awake()
    {
        InitFB();
        InitializeGA();

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }


        instance = this;
        DontDestroyOnLoad(this);
    }

    #region public Methods

    public static void GameStarted(int levelNo)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level-started-" + levelNo);
    }

    public static void GameFinished(int levelNo)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level-finished-" + levelNo);
    }

    public static void GameFailed(int levelNo)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "level-Failed-" + levelNo);
    }

    #endregion


    #region Private Methods

    private void FBInitCallback()
    {
        if (FB.IsInitialized)
        {
#if UNITY_IOS
                    FB.Mobile.SetAdvertiserTrackingEnabled(_advertiserTrackingEnabled); 
                    FB.Mobile.SetAdvertiserIDCollectionEnabled(_advertiserTrackingEnabled);
#elif UNITY_ANDROID
            FB.Mobile.SetAdvertiserIDCollectionEnabled(true);
#endif
            FB.Mobile.SetAutoLogAppEventsEnabled(true);

           
            FB.ActivateApp();
          
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void PauseUnity(bool pause)
    {
        if (!pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }


    private void InitFB()
    {
        if (!FB.IsInitialized) FB.Init(FBInitCallback, PauseUnity);

        else FBInitCallback();
    }


    private static void InitializeGA()
    {
        var gameAnalyticsComponent = FindObjectOfType<GameAnalytics>();
        if (gameAnalyticsComponent == null)
        {
            var gameAnalyticsGameObject = new GameObject("GameAnalytics");
            gameAnalyticsGameObject.AddComponent<GameAnalytics>();
            gameAnalyticsGameObject.SetActive(true);
        }
        else
        {
            gameAnalyticsComponent.gameObject.name = "GameAnalytics";
        }

        GameAnalytics.Initialize();
    }

    #endregion
}