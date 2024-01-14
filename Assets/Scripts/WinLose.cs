using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public string LevelName;

    public void retry()
    {
        string lvlName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(lvlName);
    }

    public void exit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void next()
    {
        SceneManager.LoadScene(LevelName);
    }
}
