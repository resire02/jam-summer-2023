using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTextUpdater : GameComponent
{
    [SerializeField] TextMeshProUGUI yearText;
    [SerializeField] TextMeshProUGUI eraText;

    private void Start()
    {
        Reset();
    }

    public override void Reset()
    {
        UpdateYearText(0);
        UpdateEraText(Era.Prehistoric);
    }

    public void UpdateYearText(float year)
    {
        yearText.text = $"{year.ToString("f0")}";
    }

    public void UpdateEraText(Era era)
    {
        eraText.text = $"{era.ToString()} Era";
    }
}
