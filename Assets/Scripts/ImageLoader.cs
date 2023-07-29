using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public Image background;
    private Sprite currentSprite;

    private void Start()
    {
        SetImage("CaveBackground");
    }

    //  files need to be in `Resources/Image`
    public void SetImage(string filename)
    {
        currentSprite = Instantiate(Resources.Load<Sprite>($"Image/{filename}"));
        background.sprite = currentSprite; 
    }
}
