using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private IMovement movement;
    private void Start()
    {
        movement = GetComponent<IMovement>();
    }
    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        var input = callbackContext.ReadValue<Vector2>();
        movement.SetMovement(input);
    }
}
