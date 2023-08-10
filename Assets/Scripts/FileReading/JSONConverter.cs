using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class JSONConverter : MonoBehaviour
{
    List<RandomEvent> _list;

    public class OldChoiceEvent
    {
        public int goodTechnology, goodStability, goodExploration, goodEnlightenment, goodAbundance;
        public int badTechnology, badStability, badExploration, badEnlightenment, badAbundance;
        public int chance, eventID, age;
        public string title, description, contextBad, contextGood;

        public RandomEvent ConvertToRandomEvent()
        {
            return new RandomEvent(
                (Era) ((byte) age),
                title,
                description,
                new RandomEvent.EventOutcome("Success", contextGood, new Points((float) goodTechnology, (float) goodStability, (float) goodExploration, (float) goodEnlightenment, (float) goodAbundance)),
                new RandomEvent.EventOutcome("Failure", contextBad, new Points((float) badTechnology, (float) badStability, (float) badExploration, (float) badEnlightenment, (float) badAbundance)),
                0.5f
            );
        }
    }

    private void Start()
    {
        _list = new List<RandomEvent>();

        Deserialize();
    }

    public void Deserialize()
    {
        if(_list == null) throw new Exception();
        foreach(string line in File.ReadLines(Path.Combine(Application.streamingAssetsPath, "RandomEvents.txt")))
        {
            if(line.Length <= 0) continue;
            if(line[0] != '{') continue;
            OldChoiceEvent old = JsonUtility.FromJson<OldChoiceEvent>(line);
            _list.Add(old.ConvertToRandomEvent());
        }
        
        using (StreamWriter output = new StreamWriter(Path.Combine(Application.streamingAssetsPath, "Output.txt")))
        {
            foreach(RandomEvent re in _list)
            {
                output.WriteLine(JsonUtility.ToJson(re));
            }
        }
    }
}
