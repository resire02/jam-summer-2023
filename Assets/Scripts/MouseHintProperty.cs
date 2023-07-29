using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseHintProperty : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(string text)
    {
        textComponent.text = text;
    }
    
}
