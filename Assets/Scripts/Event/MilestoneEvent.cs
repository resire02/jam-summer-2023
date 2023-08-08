using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  represents a really important event between eras
[System.Serializable]
public class MilestoneEvent
{
    /*
    Note that JsonUtility does not support field get/set or readonly properties
    So just pretend the fields are immutable
    */
    public string title;
    public string description;
    public Points points;

    public static readonly MilestoneEvent Default = new MilestoneEvent(
        "Milestone Title",
        "Milestone Description",
        Points.Zero
    );

    public MilestoneEvent(string t, string d, Points p)
    {
        title = t;
        description = d;
        points = p;
    }

    public override string ToString() => title;
    
}
