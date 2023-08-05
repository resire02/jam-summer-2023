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
    [SerializeField] private TextMeshProUGUI attempts;

    private void Start()
    {
        gameOverMenu.SetActive(false);
    }

    public void TriggerGameEnd(float score)
    {
        gameOverMenu.SetActive(true);

        AttemptCounter.IncrementAttempts();

        music.PlaySound("End", true);
        music.StopSound("Game");

        scoreText.text = $"Civilization Score: {score}";
        yearText.text = $"Civilizaton Lasted: {gameLogic.GetComponent<RandomEventHandler>().GetYear()} Years";
        attempts.text = $"Civilizations Collapsed: {AttemptCounter.attempts}";

    }

    public void ResetGame()
    {
        gameLogic.GetComponent<ProgressionTracker>().Reset();
        gameLogic.GetComponent<SpriteGenerator>().Reset();
        gameLogic.GetComponent<ImageLoader>().Reset();
        gameLogic.GetComponent<RandomEventHandler>().Reset();
        gameLogic.GetComponent<MilestoneEventHandler>().Reset();

        RandomEventList.InitializeAllEvents();
        music.PlaySound("Game", true);
        music.StopSound("End");
        gameOverMenu.SetActive(false);
    }
}
