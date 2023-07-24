using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceEvent
{
    private (int Tech, int Stablity, int Explore, int Englight, int Resource) points;
    private (string Title, string Description) text;

    public ChoiceEvent(string title, string desc, (int, int, int, int, int) change)
    {
        this.points = change;
        this.text = (title, desc);
    }

    /// GETTER METHODS
    public string GetTitle() { return text.Title; }
    public string GetDescription() { return text.Description; }
    public (int Tech, int Stablity, int Explore, int Englight, int Resource) GetPointChange() { return points; }
    
}
