using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameLogic;

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResetGame()
    {
        gameLogic.GetComponent<ProgressionTracker>().Reset();
        gameLogic.GetComponent<SpriteGenerator>().Reset();
        gameLogic.GetComponent<ImageLoader>().Reset();
        gameLogic.GetComponent<RandomEventHandler>().Reset();
        gameLogic.GetComponent<MilestoneEventHandler>().Reset();
    }
}
