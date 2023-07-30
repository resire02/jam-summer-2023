using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image foreground;
    [SerializeField] private Image transition;

    private Sprite backSprite;
    private Sprite frontSprite;
    private bool inTransition;

    private void Start()
    {
        ImageLoadedRef.Init();
        transition.color = new Color(0, 0, 0, 1);
        SetImageBackground("PrehistoricWithSky");
        SetImageForeground("PrehistoricBase");
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
    public void SetImageBackground(string filename)
    {
        transition.color = new Color(0, 0, 0, 1);
        inTransition = true;
        backSprite = Instantiate(Resources.Load<Sprite>($"Image/{filename}"));
        background.sprite = backSprite;
    }

    public void SetImageForeground(string filename)
    {
        frontSprite = Instantiate(Resources.Load<Sprite>($"Image/{filename}"));
        foreground.sprite = frontSprite;
        ScaleForeground(filename);
    }

    private void ScaleForeground(string name)
    {
        (float scale, float x, float y) properties = ImageLoadedRef.GetForegroundScalar(name);
        properties.scale = Mathf.Clamp(properties.scale, 0f, 1f);
        foreground.transform.localScale = new Vector3(properties.scale, properties.scale, properties.scale);

        foreground.transform.position = foreground.transform.position + new Vector3(properties.x, properties.y, 0f);
    }
}
