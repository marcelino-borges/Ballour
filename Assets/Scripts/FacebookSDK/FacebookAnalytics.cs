using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

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
    }
    public void LogLevelStartedEvent()
    {
        FB.LogAppEvent("Level Started");
    }
    public void LogLevelRestartEvent()
    {
        FB.LogAppEvent(
            "Level Restart"
        );
    }
    public void LogLevelFailedEvent()
    {
        FB.LogAppEvent(
            "Level Failed"
        );
    }
    public void LogLevelCompleteEvent()
    {
        FB.LogAppEvent(
            "Level Complete"
        );
    }
    public void LogTutorialCompleteEvent()
    {
        FB.LogAppEvent(
            "Tutorial Complete"
        );
    }
    public void LogHighScoreAchievedEvent()
    {
        FB.LogAppEvent(
            "High Score Achieved"
        );
    }


}
