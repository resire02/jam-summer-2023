using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGenerator : MonoBehaviour
{
    [SerializeField] private GameObject spriteContainer;

    private List<GameObject> spritesInScene;

    private void Start()
    {
        spritesInScene = new List<GameObject>();
    }

    public void AddToScene(CustomSprite sprite)
    {
        GameObject gameObject = new GameObject(sprite.spritePath);
        gameObject.transform.SetParent(spriteContainer.transform);

        Image image = gameObject.AddComponent<Image>();
        image.sprite = Instantiate(Resources.Load<Sprite>($"Image/{sprite.spritePath}"));

        gameObject.transform.Translate(new Vector3(sprite.pos.x, sprite.pos.y, 0));
        gameObject.transform.localScale = sprite.scale;

        spritesInScene.Add(gameObject);
    }

    public void ClearAllSpritesFromScene()
    {
        if(spritesInScene == null || spritesInScene.Count <= 0) return;
        
        foreach(GameObject gameObject in spritesInScene)
        {
            Destroy(gameObject);
        }

        spritesInScene.Clear();
    }
    
}
