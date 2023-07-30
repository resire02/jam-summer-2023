using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MilestoneEventList
{
    private static Dictionary<Age,MilestoneEvent> milestoneList = new Dictionary<Age,MilestoneEvent>();
    private readonly static MilestoneEvent DEFAULT = new MilestoneEvent("Milestone Title", "Milestone Description", (0, 0, 0, 0, 0));

    public static void Init()
    {
        //  TODO: add milestone events here
        milestoneList.Add(Age.Prehistoric, new MilestoneEvent(
            "Massive Flood", "There is a massive flood. Watch Out!", (-10, -10, -10, -10, -10)
        ));

        //   ...
    }

    public static MilestoneEvent GetMilestoneEvent(Age age)
    {
        if(!milestoneList.ContainsKey(age)) return DEFAULT;

        return milestoneList[age];
    }
}
