using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(RandomEventHandler))]
public class MilestoneEventHandler : MonoBehaviour
{
    [SerializeField] private GameObject milestonePanel;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private UnityEvent eventHandlerCallback;
    private ProgressionTracker progression;
    private ImageLoader imgLd;
    private MilestoneEvent milestoneEvent;
    
    private void Start()
    {
        milestonePanel.SetActive(false);
        imgLd = GetComponent<ImageLoader>();
        progression = GetComponent<ProgressionTracker>();
        MilestoneEventList.Init();
    }

    public void TriggerMilestoneEvent(Age age)
    {
        Debug.Log("Triggered Milestone Event");

        imgLd.SetScene("MilestonePlaceholder", "none");
        milestonePanel.SetActive(true);
        milestoneEvent = MilestoneEventList.GetMilestoneEvent(age);
        UpdateText();
    }

    public void HandleMilestone()
    {
        // Debug.Log("Pressed Button");

        //  TODO: write custom function to handle milestone events
        progression.AdjustProgression(milestoneEvent.GetPointChange());

        progression.AscendToNextMilestone();

        //  TODO: play sound or animation or something?
        eventHandlerCallback.Invoke();

        //  hide milestone panel after clicking
        milestonePanel.SetActive(false);
    }

    private void UpdateText()
    {
        title.text = milestoneEvent.GetTitle();
        description.text = milestoneEvent.GetDescription();
    }
}
