using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageLoadedRef
{
    private static Dictionary<string, (float, float, float)> foregroundScale = new Dictionary<string, (float, float, float)>();
    private readonly static (float, float, float) DEFAULT = (1f, 0f, 0f);

    public static void Init()
    {
        if(foregroundScale.Count > 0) return;

        //  TODO: add scalars here if necessary
        foregroundScale.Add("PrehistoricBase", (0.5f, 0f, 0f));
    }

    public static (float Scale, float XOffset, float YOffset) GetForegroundScalar(string name)
    {
        if(!foregroundScale.ContainsKey(name)) return DEFAULT;

        return foregroundScale[name];
    }
}
