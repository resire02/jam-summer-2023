using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : GameComponent
{
    [Header("Text")]
    [SerializeField] GameObject gameEndPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI yearText;
    [SerializeField] TextMeshProUGUI countText;

    [Header("Reset")]
    [SerializeField] GameObject[] modules;

    bool _pressed = false;

    private void Start()
    {
        gameEndPanel.SetActive(false);
    }

    public override void Reset()
    {
        gameEndPanel.SetActive(false);
    }

    public void DisplayGameEnd(float score, float years)
    {
        gameEndPanel.SetActive(true);
        AudioHandler.Player.PlayMusic("End");

        //  update game end text
        yearText.text = $"Years Lasted: {years.ToString("f0")}";
        scoreText.text = $"Civilization Score: {score.ToString("f0")}";
        countText.text = $"Civilizations Collapsed: {SessionTracker.IncrementAttempts()}";

        StartCoroutine(OnGameRetry());
    }

    private IEnumerator OnGameRetry()
    {
        //  wait for player press
        _pressed = false;
        yield return new WaitUntil(() => _pressed);

        foreach(GameObject obj in modules)
        {
            foreach(GameComponent comp in obj.GetComponents(typeof(GameComponent)))
            {
                comp.ResetComponent();
            }
        }
    }

    public void OnButtonPressed()
    {
        _pressed = true;
    }
}
