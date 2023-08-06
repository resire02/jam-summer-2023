using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image foreground;
    [SerializeField] private Image transition;
    [SerializeField] private UnityEvent clearSprites;

    private Sprite backSprite;
    private Sprite frontSprite;
    private bool inTransition;

    private void Start()
    {
        ImageLoadedRef.Init();
        Reset();
    }

    //  used to reset component to default state
    public void Reset()
    {
        SetScene(Age.Prehistoric);
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

    //  sets the current scene depending on the provided age
    public void SetScene(Age age)
    {
        (string bg, string fg) scene = ImageLoadedRef.GetSceneData(age);

        SetScene(scene.bg, scene.fg);
    }

    public void SetMilestoneScene(Age age)
    {
        (string bg, string fg) scene = ImageLoadedRef.GetMilestoneScene(age);

        SetScene(scene.bg, scene.fg);
    }

    //  sets the scene using the specified background and foreground respectively
    public void SetScene(string background, string foreground)
    {
        SetImageBackground(background);

        if(foreground.Equals("none"))
            this.foreground.enabled = false;
        else
            SetImageForeground(foreground);

        clearSprites.Invoke();
    }

    //  files need to be in `Resources/Image`
    private void SetImageBackground(string filename)
    {
        transition.color = new Color(0, 0, 0, 1);
        inTransition = true;
        backSprite = Instantiate(Resources.Load<Sprite>($"Image/{filename}"));
        background.sprite = backSprite;
    }

    //  files need to be in `Resources/Image` also
    private void SetImageForeground(string filename)
    {
        if(!foreground.enabled) foreground.enabled = true;

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
