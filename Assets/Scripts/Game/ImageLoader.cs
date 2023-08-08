using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class ImageLoader : GameComponent
{
    [SerializeField] Image background;
    [SerializeField] Sprite placeholder;

    Sprite _sprite;
    
    private void Start()
    {
        LoadBackground(Era.Prehistoric, false);
    }

    public override void Reset()
    {
        LoadBackground(Era.Prehistoric, false);
    }

    //  load image into background
    public void LoadBackground(Era era, bool isMilestone)
    {
        //  parse sprite name
        string filename = era.ToString();
        if(isMilestone) filename += "Milestone";

        //  attempt to load sprite
        try {
            _sprite = Instantiate(Resources.Load<Sprite>($"Image/{filename}"));
        } catch(ArgumentException) {
            Debug.LogError($"The requested file '{filename}' could not be found!");
            _sprite = placeholder;
        }

        background.sprite = _sprite;
    }

}
