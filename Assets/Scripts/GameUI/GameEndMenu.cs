using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameLogic;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI yearText;

    private void Start()
    {
        transform.gameObject.SetActive(false);
        RandomEventList.InitializeAllEvents();
    }

    public void TriggerGameEnd(float score)
    {
        transform.gameObject.SetActive(true);
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

        transform.gameObject.SetActive(false);
    }
}
