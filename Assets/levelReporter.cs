using Firebase.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelReporter : MonoBehaviour
{
    int levelNumber;

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string name = currentScene.name;
        char n = name[name.Length - 1];
        levelNumber = n;
    }

    private void Start()
    {
        // Log the level_start event with the level number.
        FirebaseAnalytics.LogEvent("level_start", "level_number", levelNumber);
    }

    private void OnDestroy()
    {
        // Log the level_complete event with the level number.
        FirebaseAnalytics.LogEvent("level_complete", "level_number", levelNumber);
    }
}
