using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] UnityEvent onPauseGame;
    [SerializeField] UnityEvent onShowTab;
    
    PlayerInput _playerInput;
    PlayerInput.NavigationActions _controls;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _controls = _playerInput.Navigation;

        //  input callbacks here
        _controls.PauseGame.performed += ctx => onPauseGame.Invoke();
        _controls.ShowResourceTab.performed += ctx => {
            if(!pauseMenu.paused) onShowTab.Invoke();
        };
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
