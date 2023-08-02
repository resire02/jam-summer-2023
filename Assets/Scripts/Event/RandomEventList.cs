using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Handles random selection of events
public static class RandomEventList
{
    private static Dictionary<Age,List<ChoiceEvent>> eventList = new Dictionary<Age,List<ChoiceEvent>>();
    private static readonly ChoiceEvent DEFAULT = new ChoiceEvent(
        ("Event Title", "Event Description"), 
        "Good Description", 
        "Bad Description", 
        (1, 1, 1, 1, 1), 
        (-1, -1, -1, -1, -1), 
        2
    );

    //  must be called before usingSelectRandomEvent!
    public static void Init()
    {
        if(eventList.Count > 0) return;

        //  initalize all lists
        eventList[Age.Prehistoric] = new List<ChoiceEvent>();
        eventList[Age.Civilization] = new List<ChoiceEvent>();
        eventList[Age.Medieval] = new List<ChoiceEvent>();
        eventList[Age.Colonial] = new List<ChoiceEvent>();
        eventList[Age.Industrial] = new List<ChoiceEvent>();
        eventList[Age.Information] = new List<ChoiceEvent>();
        eventList[Age.Space] = new List<ChoiceEvent>();
        eventList[Age.Galactic] = new List<ChoiceEvent>();
        eventList[Age.Cosmic] = new List<ChoiceEvent>();
        eventList[Age.Singularity] = new List<ChoiceEvent>();

        InitializeAllEvents();
    }

    //  returns a random ChoiceEvent from selected age and removes it from selection pool
    public static ChoiceEvent SelectRandomEvent(Age age)
    {
        if(!eventList.ContainsKey(age)) return DEFAULT;

        return SelectRandomEventFromList(eventList[age]);
    }

    //  selects a random event and removes it from the pool
    private static ChoiceEvent SelectRandomEventFromList(List<ChoiceEvent> list)
    {
        if(list.Count < 1) return DEFAULT;
        int index = Random.Range(0, list.Count);
        ChoiceEvent choice = list[index];
        list.RemoveAt(index);
        Debug.Log($"Length Modified: {list.Count}");
        return choice;
    }

    //  populates eventList with events
    private static void InitializeAllEvents()
    {
        //  TODO: add all events here
        eventList[Age.Prehistoric].Add(new ChoiceEvent(
            ("Someone has an idea", "A member of your tribe want to try to rub sticks together"),
            "Your member created fire!",
            "Nothing happened and you lost your sticks",
            (2, 0, 0, 1, 1),
            (0, -1, 0, 0, -2),
            2
        ));
        eventList[Age.Prehistoric].Add(new ChoiceEvent(
            ("Mysterious creature spotted", "One of your tribesman came running from the woods, saying he spotted a hairy animal, do you investigate?"),
            "Your tribesmen found a creature and killed it for meat",
            "You ignored your tribesman",
            (0, 1, 1, 0, 2),
            (0, 0, -1, 0, 0),
            2
        ));
    }
}
