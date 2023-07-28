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

    public TextMeshProUGUI textComponent;
    public Image barFill;
    public Image border;
    [SerializeField] private float barValue = 0f;
    [SerializeField] private float barMax = 100f;

    private void FixedUpdate()
    {
        UpdateBarFill();
        UpdateTextValue();
    }

    private void UpdateBarFill()
    {
        barValue = Mathf.Clamp(barValue, 0, barMax);
        barFill.fillAmount = barValue / barMax;
    }

    private void UpdateTextValue()
    {
        textComponent.text = $"{(int) barValue}";
    }

    public float GetBarValue() { return barValue; }
    public void SetBarValue(float value) { barValue = value; }
    public float GetBarMax() { return barMax; }

}
