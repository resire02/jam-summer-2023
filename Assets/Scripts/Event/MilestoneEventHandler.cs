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
    private ImageLoader imgLd;
    private MilestoneEvent milestoneEvent;
    
    private void Start()
    {
        milestonePanel.SetActive(false);
        imgLd = GetComponent<ImageLoader>();
        MilestoneEventList.Init();
    }

    public void TriggerMilestoneEvent(Age age)
    {
        Debug.Log("Triggered Milestone Event");

        //  TODO: prompt milestone event (no option), play cutscene?
        imgLd.SetImageBackground("MilestonePlaceholder");
        milestonePanel.SetActive(true);
        milestoneEvent = MilestoneEventList.GetMilestoneEvent(age);

        UpdateText();    
    }

    private void UpdateText()
    {
        title.text = milestoneEvent.GetTitle();
        description.text = milestoneEvent.GetDescription();
    }
}
