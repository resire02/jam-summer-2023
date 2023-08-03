using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSprite
{
    public string spritePath { get; private set; }
    public Vector2 pos { get; private set; }
    public Vector3 scale { get; private set; }

    public CustomSprite(
        string path,
        float posX,
        float posY,
        float scale) 
    {
        this.spritePath = path;
        this.pos = new Vector2(posX, posY);
        this.scale = new Vector3(scale, scale, 1);
    }
}
