using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageLoadedRef
{
    private static Dictionary<string, (float, float, float)> foregroundScale = new Dictionary<string, (float, float, float)>();
    private static Dictionary<Age, (string, string)> sceneData = new Dictionary<Age, (string, string)>();

    private readonly static (float, float, float) SCALAR_DEFAULT = (1f, 0f, 0f);
    private readonly static (string, string) SCENE_DEFAULT = ("MilestonePlaceholder", "none");

    //  initalize scene data and foregound scalars
    public static void Init()
    {
        InitForegroundScalars();
        InitAgeSceneData();
    }

    private static void InitForegroundScalars()
    {
        if(foregroundScale.Count > 0) return;

        //  TODO: add scalars here if necessary
        foregroundScale.Add("PrehistoricBase", (0.5f, 0f, 0f));
        
    }

    private static void InitAgeSceneData()
    {
        if(sceneData.Count > 0) return;

        //  TODO: add scene data for all ages excluding extinct
        sceneData.Add(Age.Prehistoric, ("PrehistoricWithSky", "PrehistoricBase"));
        sceneData.Add(Age.Civilizing, ("Civilization", "CivilizationBase"));
        sceneData.Add(Age.Medieval, ("Medieval", "Medieval"));
        sceneData.Add(Age.Colonial, ("Colonial", "Colonial"));
        sceneData.Add(Age.Industrial, ("Industrial", "Industrial"));
        sceneData.Add(Age.Information, ("Information", "Information"));
        sceneData.Add(Age.Space, ("Space", "Space"));
        sceneData.Add(Age.Cosmic, ("Cosmic", "Cosmic"));
        sceneData.Add(Age.Galactic, ("Galactic", "Galactic"));
        sceneData.Add(Age.Singularity, ("Singularity", "Singularity"));

    }

    //  GETTER METHODS

    public static (float Scale, float XOffset, float YOffset) GetForegroundScalar(string name)
    {
        if(!foregroundScale.ContainsKey(name)) return SCALAR_DEFAULT;

        return foregroundScale[name];
    }

    public static (string bg, string fg) GetSceneData(Age age)
    {
        if(!sceneData.ContainsKey(age)) return SCENE_DEFAULT;

        return sceneData[age];
    }
}
