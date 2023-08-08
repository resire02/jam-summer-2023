using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  represents a random event that can happen
[System.Serializable]
public class RandomEvent
{
    /*
    Note that JsonUtility does not support field get/set or readonly properties
    So just pretend the fields are immutable
    */
    [System.Serializable]
    public class EventOutcome
    {
        public string title;
        public string description;
        public Points points;

        public static readonly EventOutcome Default = new EventOutcome(
            "Outcome Title",
            "Description",
            Points.Zero
        );

        public EventOutcome(string t, string d, Points p)
        {
            title = t;
            description = d;
            points = p;
        }
    }

    //  class paramters
    public string title;
    public string description;
    public EventOutcome goodOutcome;
    public EventOutcome badOutcome;
    public float probability;
    public Era era;
    public int id;
    
    private static int _internalID = 0;

    public static readonly RandomEvent Default = new RandomEvent(
        Era.Prehistoric,
        "Event Title",
        "Event Description",
        EventOutcome.Default,
        EventOutcome.Default,
        0.5f
    );

    //  constructors
    public RandomEvent(Era e, string t, string d, EventOutcome good, EventOutcome bad, float prob)
    {
        era = e;
        title = t;
        description = d;
        goodOutcome = good;
        badOutcome = bad;
        probability = Mathf.Clamp(prob, 0f, 1f);
        id = _internalID++;
    }

    //  methods
    public override string ToString() => $"{id}: {title}";

    public bool IsSuccessful()
    {
        if(Random.Range(0f, 1f) <= probability)
            return true;
        return false;
    }
}
