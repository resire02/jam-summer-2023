using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilestoneEvent
{
    private string title;
    private string description;
    private (int Tech, int Stablity, int Explore, int Enlight, int Resource) points;

    public MilestoneEvent(string title, string desc, (int, int, int, int, int) points)
    {
        this.title = title;
        this.description = desc;
        this.points = points;
    }

    /// GETTER METHODS
    public (int Tech, int Stablity, int Explore, int Enlight, int Resource) GetPointChange() { return points; }
    public string GetTitle() { return title; }
    public string GetDescription() { return description; }
}
