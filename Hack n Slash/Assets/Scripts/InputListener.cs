using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputListener", menuName = "Misc/InputListener")]
public class InputListener : ScriptableObject
{
    public event Action<Vector2> OnMove;
    public event Action OnShoot;

    public void Move(InputAction.CallbackContext callbackContext)
    {
        var input = callbackContext.ReadValue<Vector2>();
        OnMove?.Invoke(input);
        Debug.Log(input);
    }

    public void Shoot(InputAction.CallbackContext callbackContext)
    {
        OnShoot?.Invoke();
    }
}
