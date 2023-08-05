using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

//  Handles random selection of events
public static class RandomEventList
{
    private static readonly string filepath = $"{Application.dataPath}/EventData/RandomEvents.txt";
    private static Dictionary<Age,List<ChoiceEvent>> eventList = new Dictionary<Age,List<ChoiceEvent>>();
    private static readonly ChoiceEvent DEFAULT = new ChoiceEvent(
        ("Event Title", "Event Description"), 
        "Good Description", 
        "Bad Description", 
        (1, 1, 1, 1, 1), 
        (-1, -1, -1, -1, -1), 
        2,
        -1
    );

    //  must be called before usingSelectRandomEvent!
    public static void Init()
    {
        if(eventList.Count > 0) return;

        //  initalize all lists
        eventList[Age.Prehistoric] = new List<ChoiceEvent>();
        eventList[Age.Civilizing] = new List<ChoiceEvent>();
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
        int index = UnityEngine.Random.Range(0, list.Count);
        ChoiceEvent choice = list[index];
        list.RemoveAt(index);
        // Debug.Log($"Length Modified: {list.Count}");
        return choice;
    }

    //  populates eventList with events
    public static void InitializeAllEvents()
    {
        foreach(Age age in eventList.Keys)
        {
            eventList[age].Clear();
        }

        //  WARNING: YANDERE DEV LEVEL CODE UP AHEAD, PROCEED AT YOUR OWN RISK!

        foreach(string line in File.ReadLines(filepath))
        {
            if(line.Length <= 0 || line[0] != '{') continue;
            ChoiceEventSerializable c = JsonUtility.FromJson<ChoiceEventSerializable>(line);
            ChoiceEvent ce = c.DeserializeObject();
            eventList[c.GetAge()].Add(ce);
        }

        foreach(Age age in eventList.Keys)
        {
            Debug.Log($"{age} contains {eventList[age].Count} elements!");
        }
    }
}
