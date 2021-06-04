using Facebook.Unity;
using UnityEngine;

public class FacebookAnalytics : MonoBehaviour
{
    public static FacebookAnalytics instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            //DebugUIText.instance.ShowText("> FB initializing");
            FB.Init(InitCallback, OnHideUnity);
            Debug.Log("FB: FB.Init() called with AppId " + FB.AppId);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            //DebugUIText.instance.ShowText("> FB already initialized");
            FB.ActivateApp();
        }
    }

    public bool IsInitialized()
    {
        return FB.IsInitialized;
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            Debug.Log("FB: Success Initialize");
            // Signal an app activation App Event
            FB.ActivateApp();
            Debug.Log("FB initialized");
            //DebugUIText.instance.ShowText("> FB initialized");
        }
        else
        {
            //DebugUIText.instance.ShowText("> FB did NOT initialize");
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
    void OnApplicationPause(bool pauseStatus)
    {
        // Check the pauseStatus to see if we are in the foreground
        // or background
        if (!pauseStatus)
        {
            //app resume
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
            }
            else
            {
                //Handle FB.Init
                FB.Init(() => {
                    FB.ActivateApp();
                });
            }
        }
    }

    // -------------------------- EVENTS --------------------------------//

    public void LogLevelStartedEvent()
    {
        if (IsInitialized())
            FB.LogAppEvent("Level Started");
        //else
        //    DebugUIText.instance.ShowText("FB.Event.LevelStarted: NOT initialized");
    }
    public void LogLevelRestartEvent()
    {
        if (IsInitialized())
            FB.LogAppEvent("Level Restart");
        //else
        //    DebugUIText.instance.ShowText("FB.Event.LevelRestart: NOT initialized");
    }
    public void LogLevelFailedEvent()
    {
        if (IsInitialized())
            FB.LogAppEvent("Level Failed");
        //else
        //    DebugUIText.instance.ShowText("FB.Event.LevelFailed: NOT initialized");
    }
    public void LogLevelCompleteEvent()
    {
        if (IsInitialized())
            FB.LogAppEvent("Level Complete");
        //else
        //    DebugUIText.instance.ShowText("FB.Event.LevelComplete: NOT initialized");
    }
    public void LogTutorialCompleteEvent()
    {
        if (IsInitialized())
            FB.LogAppEvent("Tutorial Complete");
        //else
        //    DebugUIText.instance.ShowText("FB.Event.TutorialComplete: NOT initialized");
    }
    public void LogHighScoreAchievedEvent()
    {
        if (IsInitialized())
            FB.LogAppEvent("High Score Achieved");
        //else
        //    DebugUIText.instance.ShowText("FB.Event.HighScoreAchieved: NOT initialized");
    }
}
