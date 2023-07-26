using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    
    private bool gamePaused = false;

    private void Start()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;

        if(gamePaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }

        // Debug.Log("Game Paused?");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
