using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("HAS PRESIONADO ESC");
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;

        gameIsPaused = false;
    }

    public void restart()
    {
        resume();

        SceneManager.LoadScene("Game");
    }

    public void pause()
    {

        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        gameIsPaused = true;
    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        resume();

        SceneManager.LoadScene("MainMenu");
    }

}
