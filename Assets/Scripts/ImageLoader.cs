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
        SetImage("CaveBackground");
    }

    private void FixedUpdate()
    {
        if(!inTransition) return;
    }

    //  files need to be in `Resources/Image`
    public void SetImage(string filename)
    {
        inTransition = true;
        currentSprite = Instantiate(Resources.Load<Sprite>($"Image/{filename}"));
        background.sprite = currentSprite;
    }
}
