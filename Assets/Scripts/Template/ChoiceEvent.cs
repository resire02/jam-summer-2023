using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  represents a random event that can happen
public class ChoiceEvent
{
    public PointChange resultGood;
    public PointChange resultBad;
    public (string title, string description) eventContext;
    public string contextGood;
    public string contextBad;
    private int chance;
    public int eventID;

    /// *** CONSTRUCTOR MAYHEM  *** ///

    public ChoiceEvent()
    {
        resultGood = new PointChange(0, 0, 0, 0, 0);
        resultBad = new PointChange(0, 0, 0, 0, 0);
        eventContext = ("Event Title", "Event Description");
        contextGood = "Success Description";
        contextBad = "Failure Description";
        chance = 2;
        eventID = -1;
    }

    public ChoiceEvent(
        (string, string) context,
        string goodText,
        string badText,
        (int, int, int, int, int) good,
        (int, int, int, int, int) bad,
        int prob,
        int id) : this()
    {
        eventContext = context;
        contextGood = goodText;
        contextBad = badText;
        resultGood = new PointChange(good);
        resultBad = new PointChange(bad);
        chance = prob;
        eventID = id;
    }

    public ChoiceEvent(
        (string, string) context,
        string goodText,
        string badText,
        PointChange good,
        PointChange bad,
        int prob,
        int id) : this()
    {
        eventContext = context;
        contextGood = goodText;
        contextBad = badText;
        resultGood = good;
        resultBad = bad;
        chance = prob;
        eventID = id;
    }

    public override string ToString()
    {
        return eventContext.title;
    }

    //  a chance value of `2` means the chance of success is 1 in 2 (50%)
    public bool GambleSuccess()
    {
        if(Random.Range(0, chance) == 0)
            return true;
        return false;
    }
}
