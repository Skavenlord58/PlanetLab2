using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool PauseFlag = false;
    public GameObject pauseMenu;


    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseFlag = true;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseFlag = false;
        AudioListener.pause = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseFlag)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}
}
