using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void gameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
