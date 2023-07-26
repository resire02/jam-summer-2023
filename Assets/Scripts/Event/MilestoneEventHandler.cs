using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomEventHandler))]
public class MilestoneEventHandler : MonoBehaviour
{
    public void TriggerMilestoneEvent(Age age)
    {
        Debug.Log("Triggered Milestone Event");

        //  TODO: prompt milestone event (no option), play cutscene?
    }
}
