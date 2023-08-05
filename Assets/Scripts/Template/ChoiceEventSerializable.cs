using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceEventSerializable
{
    public int goodTechnology, goodStability, goodExploration, goodEnlightenment, goodAbundance;
    public int badTechnology, badStability, badExploration, badEnlightenment, badAbundance;
    public int chance, eventID, age;
    public string title, description, contextGood, contextBad;

    public ChoiceEventSerializable()
    {
        goodTechnology = 0;
        goodStability = 0;
        goodExploration = 0;
        goodEnlightenment = 0;
        goodAbundance = 0;
        badTechnology = 0;
        badStability = 0;
        badExploration = 0;
        badEnlightenment = 0;
        badAbundance = 0;
        chance = 2;
        eventID = -1;
        title = "title";
        description = "description";
        contextGood = "good";
        contextBad = "bad";
        age = 1;
    }

    public ChoiceEvent DeserializeObject()
    {
        return new ChoiceEvent(
            (title, description),
            contextGood,
            contextBad,
            (goodTechnology, goodStability, goodExploration, goodEnlightenment, goodAbundance),
            (badTechnology, badStability, badExploration, badEnlightenment, badAbundance),
            chance,
            eventID
        );
    }

    public Age GetAge()
    {
        return (Age) age;
    }
}

