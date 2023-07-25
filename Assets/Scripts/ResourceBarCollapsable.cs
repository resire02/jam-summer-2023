using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBarCollapsable : MonoBehaviour
{
    public GameObject resourceBar;
    private Animator animator;
    private bool resourceBarVisible = false;

    public void Start()
    {
        animator = resourceBar.GetComponent<Animator>();
    }

    /// For button functionality
    public void ToggleResourceBar()
    {
        resourceBarVisible = !resourceBarVisible;
        animator.SetBool("ResourceBarVisible", resourceBarVisible);
    }
}
