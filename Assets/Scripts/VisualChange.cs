using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VisualChange : MonoBehaviour
{
    [SerializeField] private GameObject arrowContainer;
    [SerializeField] private Sprite upArrow;
    [SerializeField] private Sprite downArrow;
    [SerializeField] private Sprite noChangeSprite;

    private List<Image> arrowImages;
    private Animator animator;

    private void Start()
    {
        animator = arrowContainer.GetComponent<Animator>();

        arrowImages = new List<Image>();

        //  populate image list   
        foreach(Image image in arrowContainer.GetComponentsInChildren<Image>())
        {
            arrowImages.Add(image);
        }

        if(arrowImages.Count != 5) throw new Exception("VisualChange does not contain the required amount of elements");
    }

    public void TriggerAnimation(PointChange change)
    {
        SetVisualIndicators(change);

        animator.SetTrigger("PlayArrowAnimation");
    }

    private void SetVisualIndicators(PointChange change)
    {
        arrowImages[0].sprite = (change.technology == 0f) ? noChangeSprite : (change.technology > 0f) ? upArrow : downArrow;
        arrowImages[1].sprite = (change.stability == 0f) ? noChangeSprite : (change.stability > 0f) ? upArrow : downArrow;
        arrowImages[2].sprite = (change.exploration == 0f) ? noChangeSprite : (change.exploration > 0f) ? upArrow : downArrow;
        arrowImages[3].sprite = (change.enlightenment == 0f) ? noChangeSprite : (change.enlightenment > 0f) ? upArrow : downArrow;
        arrowImages[4].sprite = (change.abundance == 0f) ? noChangeSprite : (change.abundance > 0f) ? upArrow : downArrow;
    }

}
