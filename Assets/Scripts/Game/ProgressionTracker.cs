using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Stores civilization parameters
public class ProgressionTracker : GameComponent
{
    public float technology     { get; private set; } = 0f;
    public float stability      { get; private set; } = 0f;
    public float exploration    { get; private set; } = 0f;
    public float enlightenment  { get; private set; } = 0f;
    public float abundance      { get; private set; } = 0f;
    public Era era              { get; private set; } = Era.Prehistoric;

    [SerializeField] float milestoneScalar = 5f;
    [SerializeField] ResourceUpdater barUpdater;
    float _scalar = 1f;
    readonly byte HighestEra = 10;

    //  resets class to default state
    public override void Reset()
    {
        technology = 0f;
        stability = 0f;
        exploration = 0f;
        enlightenment = 0f;
        abundance = 0f;
        era = Era.Prehistoric;
        _scalar = 1f;
    }

    //  modifies current values
    public void AdjustProgression(Points pointChange)
    {        
        technology = Mathf.Max(pointChange.technology * _scalar + technology, 0f);
        stability = Mathf.Max(pointChange.stability * _scalar + stability, 0f);
        exploration = Mathf.Max(pointChange.exploration * _scalar + exploration, 0f);
        enlightenment = Mathf.Max(pointChange.enlightenment * _scalar + enlightenment, 0f);
        abundance = Mathf.Max(pointChange.abundance * _scalar + abundance, 0f);
    }

    //  checks if the player survives the event
    public bool SurvivesEvent(Points pointChange)
    {
        //  ensure player always loses to the great filtler
        if(era == Era.Singularity) return false;

        //  calcuate result
        float t = technology - (pointChange.technology * _scalar);
        float s = stability - (pointChange.stability * _scalar);
        float ex = exploration - (pointChange.exploration * _scalar);
        float en = enlightenment - (pointChange.enlightenment * _scalar);
        float a = abundance - (pointChange.abundance * _scalar);

        //  returns true if at least 3 values are greater than zero
        int count = 0;
        foreach(float parameter in pointChange.GetEnumerator())
            if(parameter <= 0f) count++;
        return count < 3;    
    }

    //  increments to next milestone
    public void ToNextMilestone()
    {
        //  increment to next milestone
        byte next = (byte) era;
        if(next < HighestEra) next++;
        era = (Era) next;
        
        //  increase scalar
        _scalar *= milestoneScalar;
        barUpdater.ScaleMax(milestoneScalar);
    }

    //  calculates final score
    public float CalculateScore()
    {
        return (technology + stability + exploration + enlightenment + abundance) / 5f;
    }

    public Points ValuesAsPoints()
    {
        return new Points(technology, stability, exploration, enlightenment, abundance);
    }
}
