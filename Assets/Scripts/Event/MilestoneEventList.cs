using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MilestoneEventList
{
    static Dictionary<Era,MilestoneEvent> _milestoneList = new Dictionary<Era,MilestoneEvent>();

    static bool _isInitalized = false;

    public static void Init()
    {
        if(_isInitalized) return;

        _milestoneList[Era.Prehistoric] = new MilestoneEvent(
            "Ice Age", 
            "You feel the air around you becoming colder. In fact, it's becoming too cold. The plants around you start to wither and the animals starting to hibernate. You immediately take shelter in your cave along with your tribe as an intense snow storm hits.", 
            new Points(-10, -10, -10, -10, -10)
        );

        _milestoneList[Era.Civilizing] = new MilestoneEvent(
            "Volcanic Eruption",
            "A nearby mountain suddenly implodes on itself and lava has begun to stream down the cliff, consuming all the animals and planets in its path of destruction. The earth beneath you starts to rumble violently, as if the heavens raged war on your land.",
            new Points(-10, -10, -10, -10, -10)
        );

        _milestoneList[Era.Medieval] = new MilestoneEvent(
            "Plague of Death",
            "The towns surrounding the castle have grown bleak, the people withering away. A mysterious plague sweeps the land, the people drop as the years toil.",
            new Points(-15, -15, -15, -15, -15)
        );

        _milestoneList[Era.Colonial] = new MilestoneEvent(
            "Hypercane",
            "A mighty breeze followed by a stronger breeze, the vegetation is uprooted as the towns are blown apart. But the only thing you seem to notice is the massive water wave coming straight for you.",
            new Points(-15, -15, -15, -15, -15)
        );

        _milestoneList[Era.Industrial] = new MilestoneEvent(
            "Nuclear Storm",
            "In a futile effort to prove their dominance, all the countries of the world launched their nukes at each other, generating a global network of radioactive storms, ready to rain death upon you.",
            new Points(-15, -15, -15, -15, -15)
        );
        
        _milestoneList[Era.Information] = new MilestoneEvent(
            "AI Apocalypse",
            "The machines begin to question man's dominance, converting every electronic into a weapon of mass destruction with one goal: to eliminate all of humanity.",
            new Points(-15, -15, -15, -15, -15)
        );

        _milestoneList[Era.Space] = new MilestoneEvent(
            "Solar Flare",
            "A massive surge of radiation shoots out from the Sun in every direction, vaporizing every object upon contact and engulfing the planets in an unforgiving solar storm.",
            new Points(-15, -15, -15, -15, -15)
        );

        _milestoneList[Era.Galactic] = new MilestoneEvent(
            "Supernova",
            "A set of unstable stars collapse, sending an unimaginably destructive shock wave rippling through the galaxy.",
            new Points(-15, -15, -15, -15, -15)
        );

        _milestoneList[Era.Cosmic] = new MilestoneEvent(
            "Supermassive Blackhole",
            "At the core of the universe, a supermassive blackhole awaits and beckons all those who dare approach to test their courage. However, it's not waiting anymore.",
            new Points(-15, -15, -15, -15, -15)
        );

        _milestoneList[Era.Singularity] = new MilestoneEvent(
            "The Great Filter",
            "Those that begin must have an end.",
            new Points(-10, -10, -10, -10, -10)
        );

        _isInitalized = true;
    }

    public static MilestoneEvent GetMilestoneEventFromEra(Era era)
    {
        if(!_milestoneList.ContainsKey(era))
            return MilestoneEvent.Default;
        return _milestoneList[era];
    }
}
