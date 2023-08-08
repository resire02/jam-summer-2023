using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceBarAnimation : MonoBehaviour
{
    [SerializeField] Animator resourceBarAnimator;

    bool _visible = false;

    //  Toggles resource bar visibility
    public void ToggleResourceBar()
    {
        _visible = !_visible;

        resourceBarAnimator.SetBool("ResourceBarVisible", _visible);
    }
}
