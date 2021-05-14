
using UnityEngine;
using com.adjust.sdk;

public class AdjustExample : MonoBehaviour
{
    public string APP_TOKEN = "uouv2hlnxq80";
    void Start()
    {
#if UNITY_IOS
        /* Mandatory - set your iOS app token here */
        InitAdjust("");
#elif UNITY_ANDROID
        /* Mandatory - set your Android app token here */
        InitAdjust(APP_TOKEN);
#endif
    }

    private void InitAdjust(string adjustAppToken)
    {
        var adjustConfig = new AdjustConfig(
            adjustAppToken,
            AdjustEnvironment.Production, // AdjustEnvironment.Sandbox to test in dashboard
            true
        );
        adjustConfig.setLogLevel(AdjustLogLevel.Info); // AdjustLogLevel.Suppress to disable logs
        adjustConfig.setSendInBackground(true);
        new GameObject("Adjust").AddComponent<Adjust>(); // do not remove or rename

        // Adjust.addSessionCallbackParameter("foo", "bar"); // if requested to set session-level parameters

        //adjustConfig.setAttributionChangedDelegate((adjustAttribution) => {
        //  Debug.LogFormat("Adjust Attribution Callback: ", adjustAttribution.trackerName);
        //});

        Adjust.start(adjustConfig);

    }

}