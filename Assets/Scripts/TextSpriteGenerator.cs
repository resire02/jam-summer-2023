using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSpriteGenerator : MonoBehaviour
{
    public Color acceptColor;
    public Color declineColor;
    [SerializeField] private TextMeshProUGUI textSprite;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerAnimation(ChoiceEvent cEvent, int choice)
    {
        (int t, int s, int e, int en, int a) points;

        if(choice == 1)
        {
            textSprite.color = acceptColor;
            points = cEvent.GetAcceptPointChange();
        }
        else
        {
            textSprite.color = declineColor;
            points = cEvent.GetDeclinePointChange();
        }

        SetPointValues(points.t, points.s, points.e, points.en, points.a);
        animator.SetTrigger("PlayTextSpriteFade");
    }

    private void SetPointValues(int t, int s, int e, int en, int a)
    {
        textSprite.text = $"{AppendPlus(t)}{t} {AppendPlus(s)}{s} {AppendPlus(e)}{e} {AppendPlus(en)}{en} {AppendPlus(a)}{a}";
    }

    private string AppendPlus(int num)
    {
        if(num >= 0)
            return "+";
        return "";
    }
}
