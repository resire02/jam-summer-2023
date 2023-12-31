using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseHintProperty : GameComponent
{
    [SerializeField] private TextMeshProUGUI textTitle;
    [SerializeField] private TextMeshProUGUI textDescription;

    private void Start()
    {
        Reset();
    }

    public override void Reset()
    {
        ClearAllText();
    }

    public void UpdateTextTitle(string title)
    {
        textTitle.text = title;
    }

    public void UpdateTextDescription(string description)
    {
        textDescription.text = description;
    }

    public void ClearAllText()
    {
        textTitle.text = string.Empty;
        textDescription.text = string.Empty;
    }
    
}
