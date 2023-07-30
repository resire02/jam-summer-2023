using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceBarCollapsable : MonoBehaviour
{
    public GameObject resourceBar;
    private Animator animator;
    private bool resourceBarVisible = false;
    public AudioRequest sound;

    public void Start()
    {
        animator = resourceBar.GetComponent<Animator>();
    }

    /// For button functionality
    public void ToggleResourceBar()
    {
        resourceBarVisible = !resourceBarVisible;

        if(resourceBarVisible)
            sound.Invoke("TabOpen", false);
        else
            sound.Invoke("TabClosed", false);

        animator.SetBool("ResourceBarVisible", resourceBarVisible);
    }
}
