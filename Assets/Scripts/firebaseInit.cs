using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;

public class firebaseInit : MonoBehaviour
{
    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }
}
