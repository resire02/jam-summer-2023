using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        AudioHandler.Player.PlaySFX("MenuButton");

        Invoke(nameof(AppStart), 1f);
    }

    public void QuitGame()
    {
        Debug.Log("Game was Quitted!");

        AudioHandler.Player.PlaySFX("MenuButton");
        
        Invoke(nameof(AppQuit), 1f);
    }

    private void AppStart()
    {
        SceneManager.LoadScene("Game");
    }

    private void AppQuit()
    {
        Application.Quit();
    }
}
