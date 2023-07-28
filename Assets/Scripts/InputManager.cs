using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent onPauseGame;
    public UnityEvent onShowTab;
    
    private PlayerInput playerInput;
    private PlayerInput.NavigationActions controls;

    private void Awake()
    {
        playerInput = new PlayerInput();
        controls = playerInput.Navigation;

        controls.PauseGame.performed += ctx => onPauseGame.Invoke();
        controls.ShowResourceTab.performed += ctx => onShowTab.Invoke();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
