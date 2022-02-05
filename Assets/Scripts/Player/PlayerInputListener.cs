using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerInputListener : MonoBehaviour
{
    private PlayerMovement controller;

    private void Awake() {
        this.controller = GetComponent<PlayerMovement>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed) {
            Vector2 movement = context.ReadValue<Vector2>();
            this.controller.OnMovement(movement.x);
        } else if (context.canceled) {
            this.controller.OnMovement(0f);
        }
    }
}