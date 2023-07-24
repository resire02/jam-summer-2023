using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPopup : MonoBehaviour
{
    [SerializeField] private GameObject eventBar;
    private bool isVisible = false;
    private Animator animator;

    private void Start()
    {
        animator = eventBar.GetComponent<Animator>();
    }

    public void ToggleEventBar()
    {
        isVisible = !isVisible;
        animator.SetBool("EventBarVisible", isVisible);
    }
}
