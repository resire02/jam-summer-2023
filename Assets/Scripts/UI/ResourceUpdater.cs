using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUpdater : GameComponent
{
    [SerializeField] ResourceProgressBar barTech;
    [SerializeField] ResourceProgressBar barStab;
    [SerializeField] ResourceProgressBar barExplore;
    [SerializeField] ResourceProgressBar barEnlighten;
    [SerializeField] ResourceProgressBar barAbund;

    float _startingMax;

    private void Start()
    {
        Reset();
    }

    public override void Reset()
    {
        _startingMax = 100f;
        UpdateMax(_startingMax);
    }

    public void UpdateValues(Points points)
    {
        barTech.SetValue(points.technology);
        barStab.SetValue(points.stability);
        barExplore.SetValue(points.exploration);
        barEnlighten.SetValue(points.enlightenment);
        barAbund.SetValue(points.abundance);
    }

    public void UpdateMax(float max)
    {
        barTech.SetMax(max);
        barStab.SetMax(max);
        barExplore.SetMax(max);
        barEnlighten.SetMax(max);
        barAbund.SetMax(max);
    }

    public void ScaleMax(float scalar)
    {
        _startingMax *= scalar;
    }
}
