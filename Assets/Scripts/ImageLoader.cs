using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image transition;
    private Sprite currentSprite;

    private bool inTransition;

    private void Start()
    {
        transition.color = new Color(0, 0, 0, 1);
        SetImage("PrehistoricWithSky");
    }

    private void FixedUpdate()
    {
        if(!inTransition) return;
        
        if(transition.color.a > 0f)
        {
            Color c = transition.color;
            c.a -= 0.01f;
            transition.color = c;
        }
        else
        {
            inTransition = true;
        }
    }

    //  files need to be in `Resources/Image`
    public void SetImage(string filename)
    {
        transition.color = new Color(0, 0, 0, 1);
        inTransition = true;
        currentSprite = Instantiate(Resources.Load<Sprite>($"Image/{filename}"));
        background.sprite = currentSprite;
    }
}
