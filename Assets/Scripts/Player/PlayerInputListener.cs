using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerInputListener : MonoBehaviour
{
    private PlayerMovement controller;

    private void Awake() {
        controller = GetComponent<PlayerMovement>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed) {
            Vector2 movement = context.ReadValue<Vector2>();
            controller.OnMovement(movement.x);
        } else if (context.canceled) {
            controller.OnMovement(0f);
        }
    }
}