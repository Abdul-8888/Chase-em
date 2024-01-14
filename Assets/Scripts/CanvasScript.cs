using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    private string lvlName;

    public void restart()
    {
        lvlName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(lvlName);
    }

    public void exit()
    {
        SceneManager.LoadScene("Menu");
    }
}