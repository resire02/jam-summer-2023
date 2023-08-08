using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

//  Handles random selection of events
public static class RandomEventList
{
    static readonly string _filepath = $"{Application.streamingAssetsPath}/RandomEvents.txt";
    static Dictionary<Era,List<RandomEvent>> _eventList = new Dictionary<Era,List<RandomEvent>>();
    static bool _isInitalized = false;

    public static void Init()
    {
        if(_isInitalized) return;

        //  initalize all lists
        foreach(Era era in Enum.GetValues(typeof(Era)))
        {
            _eventList[era] = new List<RandomEvent>();
        }

        PopulateEventList();

        _isInitalized = true;
    }
    
    public static void RepopulateList()
    {
        if(!_isInitalized) throw new Exception("RandomEventList not initalized!");

        foreach(Era era in _eventList.Keys)
        {
            _eventList[era].Clear();
        }

        PopulateEventList();
    }

    //  randomly picks and removes an event from the pool
    public static RandomEvent DrawRandomEventFromEra(Era era)
    {
        if(!_isInitalized) throw new Exception("RandomEventList not initalized!");

        if(_eventList[era].Count < 1) return RandomEvent.Default;

        return DrawRandomEvent(_eventList[era], era);
    }
    
    //  choose and remove random event from list
    private static RandomEvent DrawRandomEvent(List<RandomEvent> list, Era era)
    {
        int index = UnityEngine.Random.Range(0, list.Count);
        RandomEvent choice = list[index];
        list.RemoveAt(index);
        return choice;
    }

    //  populates event list from json
    private static void PopulateEventList()
    {
        //  create file if it doesn't exist
        if(!File.Exists(_filepath)) File.Create(_filepath);

        //  read filepath
        int lineCount = 0;

        foreach(string line in File.ReadLines(_filepath))
        {
            lineCount++;
            
            if(line.Length == 0) continue;  //  ignore empty lines
            string json = line.Trim();      //  remove whitespace characters
            if(json[0] != '{') continue;    //  ignore non json lines

            try {
                RandomEvent obj = JsonUtility.FromJson<RandomEvent>(json);  //  deserialize object
                _eventList[obj.era].Add(obj);                               //  add to event list
            } catch(KeyNotFoundException) {
                Debug.LogError($"Line {lineCount} could not be deserialized!");
                continue;
            }
        }
    }

}
