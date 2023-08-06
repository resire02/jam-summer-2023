using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EraTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI era;

    private ProgressionTracker progression;

    private void Start()
    {
        progression = GetComponent<ProgressionTracker>();
    }

    private void FixedUpdate()
    {
        era.text = $"{progression.GetTechnologicalStage().ToString()} Era";
    }
}
