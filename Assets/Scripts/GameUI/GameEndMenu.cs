using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject gameLogic;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI yearText;
    [SerializeField] private AudioHandler music;

    private void Start()
    {
        gameOverMenu.SetActive(false);
        RandomEventList.InitializeAllEvents();
    }

    public void TriggerGameEnd(float score)
    {
        gameOverMenu.SetActive(true);
        music.PlaySound("End", true);
        music.StopSound("Game");
        scoreText.text = $"Civilization Score: {score}";
        yearText.text = $"Civilizaton Lasted: {gameLogic.GetComponent<RandomEventHandler>().GetYear()} Years";
    }

    public void ResetGame()
    {
        gameLogic.GetComponent<ProgressionTracker>().Reset();
        gameLogic.GetComponent<SpriteGenerator>().Reset();
        gameLogic.GetComponent<ImageLoader>().Reset();
        gameLogic.GetComponent<RandomEventHandler>().Reset();
        gameLogic.GetComponent<MilestoneEventHandler>().Reset();

        music.PlaySound("Game", true);
        music.StopSound("End");
        gameOverMenu.SetActive(false);
    }
}
