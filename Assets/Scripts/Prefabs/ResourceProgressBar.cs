using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class ResourceProgressBar : MonoBehaviour
{
    #if UNITY_EDITOR
        [MenuItem("GameObject/UI/Resource Progress Bar")]
        public static void AddResourceProgressBar()
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Resource Progress Bar"));
            obj.transform.SetParent(Selection.activeGameObject.transform, false);
        }
    #endif

    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Image barFill;
    [SerializeField] Image border;
    
    public float value { get; private set; } = 0f;
    public float max { get; private set; } = 100f;

    private void FixedUpdate()
    {
        float fill = Mathf.Clamp(value, 0, max);
        barFill.fillAmount = fill / max;
        textComponent.text = $"{value.ToString("f0")}";
    }

    public void SetValue(float val) { value = val; }

    public void SetMax(float max) { this.max = max; }

}

