using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGenerator : MonoBehaviour
{
    [SerializeField] private GameObject spriteContainer;

    private List<GameObject> spritesInScene;
    private Dictionary<int, CustomSprite> spriteMap;
    private readonly float X_Center = 1920f / 2f;
    private readonly float Y_Center = 1080f / 2f;

    private void Start()
    {
        spritesInScene = new List<GameObject>();
        spriteMap = new Dictionary<int, CustomSprite>();

        PopulateSpriteMap();
    }

    public void Reset()
    {
        ClearAllSpritesFromScene();
    }

    private void PopulateSpriteMap()
    {
        //  TODO: add to sprite map
        spriteMap.Add(1, new CustomSprite("PrehistoricBaseWithLogWithFire", X_Center, Y_Center, 0.5f));
    }

    public void AddToScene(int id)
    {
        if(id <= 0) return;
        
        if(spriteMap.ContainsKey(id)) AddToScene(spriteMap[id]);
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
