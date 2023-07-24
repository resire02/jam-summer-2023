using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomEventList
{
    private static Dictionary<Age,List<ChoiceEvent>> eventList = new Dictionary<Age,List<ChoiceEvent>>();
    private static readonly ChoiceEvent DEFAULT = new ChoiceEvent("Event Title", "Event Text", (0, 0, 0, 0, 0));

    //  must be called before usingSelectRandomEvent!
    public static void Init()
    {
        InitializeAllEvents();
    }

    //  returns a random ChoiceEvent from selected age and removes it from selection pool
    public static ChoiceEvent SelectRandomEvent(Age age)
    {
        if(!eventList.ContainsKey(age)) return DEFAULT;

        return SelectRandomEventFromList(eventList[age]);
    }

    private static ChoiceEvent SelectRandomEventFromList(List<ChoiceEvent> list)
    {
        if(list.Count < 1) return DEFAULT;
        int index = Random.Range(0, list.Count - 1);
        ChoiceEvent choice = list[index];
        list.RemoveAt(index);
        return choice;
    }

    //  populates eventList with events
    private static void InitializeAllEvents()
    { 
        eventList[Age.Prehistoric] = new List<ChoiceEvent>();
        eventList[Age.Civilization] = new List<ChoiceEvent>();
        eventList[Age.Medieval] = new List<ChoiceEvent>();
        eventList[Age.Colonial] = new List<ChoiceEvent>();
        eventList[Age.Industrial] = new List<ChoiceEvent>();
        eventList[Age.Information] = new List<ChoiceEvent>();
        eventList[Age.Space] = new List<ChoiceEvent>();
        eventList[Age.Galactic] = new List<ChoiceEvent>();
        eventList[Age.Cosmic] = new List<ChoiceEvent>();
        // eventList[Age.Singularity] = new List<ChoiceEvent>();

        //  TODO: add all events here
        eventList[Age.Prehistoric].Add(new ChoiceEvent("Humans dumb", "humans are dumb", (-10, -10, -10, -10, -10)));
    }
}
