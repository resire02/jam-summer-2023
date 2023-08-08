using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  useful class for storing changes in parameters
[System.Serializable]
public class Points
{
    public float technology;
    public float stability;   
    public float exploration;
    public float enlightenment;
    public float abundance;

    public static readonly Points Zero = new Points(0, 0, 0, 0, 0);

    public Points(float tech, float stab, float explor, float enlight, float abund)
    {
        technology = tech;
        stability = stab;
        exploration = explor;
        enlightenment = enlight;
        abundance = abund;
    }

    public IEnumerable<float> GetEnumerator()
    {
        yield return technology;
        yield return stability;
        yield return exploration;
        yield return enlightenment;
        yield return abundance;
    }

}
