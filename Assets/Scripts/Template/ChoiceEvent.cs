using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceEvent
{
    private (int Tech, int Stablity, int Explore, int Enlight, int Resource) acceptPoints;
    private (int Tech, int Stablity, int Explore, int Enlight, int Resource) declinePoints;
    private (string Title, string Description) text;

    public ChoiceEvent(string title, string desc, (int, int, int, int, int) accept, (int, int, int, int, int) decline)
    {
        this.acceptPoints = accept;
        this.declinePoints = decline;
        this.text = (title, desc);
    }

    /// GETTER METHODS
    public string GetTitle() { return text.Title; }
    public string GetDescription() { return text.Description; }
    public (int Tech, int Stablity, int Explore, int Enlight, int Resource) GetAcceptPointChange() { return acceptPoints; }
    public (int Tech, int Stablity, int Explore, int Enlight, int Resource) GetDeclinePointChange() { return declinePoints; }
    
}
