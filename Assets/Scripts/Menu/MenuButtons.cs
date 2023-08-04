using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private AudioRequest request;

    public void StartGame()
    {
        request.Invoke("MenuButton", false);

        Invoke(nameof(AppStart), 1f);
    }

    public void QuitGame()
    {
        Debug.Log("Game was Quitted!");

        request.Invoke("MenuButton", false);
        
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
