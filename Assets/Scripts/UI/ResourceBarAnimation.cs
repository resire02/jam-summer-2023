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

        if(_visible)
            AudioHandler.Player.PlaySFX("TabOpen");
        else
            AudioHandler.Player.PlaySFX("TabClosed");

        resourceBarAnimator.SetBool("ResourceBarVisible", _visible);
    }
}
