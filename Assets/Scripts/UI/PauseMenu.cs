using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    public bool paused { get; private set; } = false;

    private void Start()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void TogglePauseGame()
    {
        paused = !paused;

        if(paused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }

        AudioHandler.Player.PlaySFX("MenuButton");
    }

    public void ExitToMainMenu()
    {
        AudioHandler.Player.PlaySFX("MenuButton");
        
        SceneManager.LoadScene("Menu");
    }
}
