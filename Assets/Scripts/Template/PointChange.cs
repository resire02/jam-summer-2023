using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  useful class for storing point changes
public class PointChange
{
    public int technology       { get; private set; }
    public int stability        { get; private set; }
    public int exploration      { get; private set; }
    public int enlightenment    { get; private set; }
    public int abundance        { get; private set; }

    public PointChange(int tech, int stab, int explor, int enlight, int abund)
    {
        technology = tech;
        stability = stab;
        exploration = explor;
        enlightenment = enlight;
        abundance = abund;
    }

    public PointChange((int tech, int stab, int explor, int enlight, int abund) change)
    {
        technology      =   change.tech;
        stability       =   change.stab;
        exploration     =   change.explor;
        enlightenment   =   change.enlight;
        abundance       =   change.abund;
    }
}
