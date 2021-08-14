using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputListener", menuName = "Systems/InputListener")]
public class InputListener : ScriptableObject
{
    public event Action<Vector2> OnMove;
    public event Action OnFire, OnInteract, OnEscape;

    public bool EnableInput { get; set; } = true;



    private void OnEnable() => EnableInput = true;

    public void Move(InputAction.CallbackContext callbackContext)
    {
        if (!EnableInput)
        {
            OnMove?.Invoke(Vector2.zero);
            return;
        }

        if (callbackContext.performed)
        {
            var input = callbackContext.ReadValue<Vector2>();
            Debug.Log("pressed");
            OnMove?.Invoke(input);
        }
        if (callbackContext.canceled)
        {
            OnMove?.Invoke(Vector2.zero);
        }
    }

    public void Shoot(InputAction.CallbackContext callbackContext)
    {
        if (!EnableInput) return;
        if (callbackContext.started)
        {
            OnFire?.Invoke();
        }
    }
    public void Interact(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {

            OnInteract?.Invoke();
        }
    }
    public void Escape(InputAction.CallbackContext callbackContext)
    {
        OnEscape?.Invoke();
    }
}
