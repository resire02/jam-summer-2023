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
    [SerializeField] private Sprite noChange;

    List<Image> _arrowImages;
    Animator _animator;

    private void Start()
    {
        _animator = arrowContainer.GetComponent<Animator>();

        _arrowImages = new List<Image>();

        //  populate image list
        foreach(Image image in arrowContainer.GetComponentsInChildren<Image>())
        {
            _arrowImages.Add(image);
        }

        if(_arrowImages.Count != 5) throw new Exception("VisualChange does not contain the required amount of elements");
    }

    public void TriggerAnimation(Points change)
    {
        SetVisualIndicators(change);

        _animator.SetTrigger("PlayArrowAnimation");
    }

    private void SetVisualIndicators(Points change)
    {
        _arrowImages[0].sprite = (change.technology == 0f) ? noChange : (change.technology > 0f) ? upArrow : downArrow;
        _arrowImages[1].sprite = (change.stability == 0f) ? noChange : (change.stability > 0f) ? upArrow : downArrow;
        _arrowImages[2].sprite = (change.exploration == 0f) ? noChange : (change.exploration > 0f) ? upArrow : downArrow;
        _arrowImages[3].sprite = (change.enlightenment == 0f) ? noChange : (change.enlightenment > 0f) ? upArrow : downArrow;
        _arrowImages[4].sprite = (change.abundance == 0f) ? noChange : (change.abundance > 0f) ? upArrow : downArrow;
    }
}
