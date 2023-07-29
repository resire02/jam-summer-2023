using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTextUpdater : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public void UpdateText(float time)
    {
        timeText.text = $"{Mathf.Floor(time)}";
    }
}
