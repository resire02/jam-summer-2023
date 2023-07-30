using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomEventHandler))]
public class MilestoneEventHandler : MonoBehaviour
{
    [SerializeField] private GameObject milestonePanel;
    private ImageLoader imgLd;
    
    private void Start()
    {
        milestonePanel.SetActive(false);
        imgLd = GetComponent<ImageLoader>();
    }

    public void TriggerMilestoneEvent(Age age)
    {
        Debug.Log("Triggered Milestone Event");

        //  TODO: prompt milestone event (no option), play cutscene?
        imgLd.SetImage("MilestonePlaceholder");
        milestonePanel.SetActive(true);
    }
}
