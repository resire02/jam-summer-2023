using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilestoneEvent
{
    private string title;
    private string description;
    private PointChange points;

    //  Constructors

    public MilestoneEvent(string title, string desc, (int, int, int, int, int) points)
    {
        this.title = title;
        this.description = desc;
        this.points = new PointChange(points);
    }

    public MilestoneEvent(string title, string desc, PointChange points)
    {
        this.title = title;
        this.description = desc;
        this.points = points;
    }

    /// GETTER METHODS
    public PointChange GetPointChange() { return points; }
    public string GetTitle() { return title; }
    public string GetDescription() { return description; }
}
