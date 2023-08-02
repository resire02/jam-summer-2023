using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSpriteGenerator : MonoBehaviour
{
    public Color successColor;
    public Color failureColor;
    [SerializeField] private TextMeshProUGUI textSprite;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetStatusColor(int status) 
    {
        if(status > 0)
            textSprite.color = successColor;
        else
            textSprite.color = failureColor;
    }

    //  use this to call animation
    public void TriggerAnimation(PointChange points)
    {
        UpdateText(points);
        animator.SetTrigger("PlayTextSpriteFade");
    }

    private void UpdateText(PointChange change)
    {
        textSprite.text = $"{FormatNumber(change.technology)} {FormatNumber(change.stability)} {FormatNumber(change.exploration)} {FormatNumber(change.enlightenment)} {FormatNumber(change.abundance)}";
    }

    //  adds leading plus if necessary
    private string FormatNumber(int num)
    {
        if(num >= 0)
            return $"+{num}";
        return $"{num}";
    }
}
