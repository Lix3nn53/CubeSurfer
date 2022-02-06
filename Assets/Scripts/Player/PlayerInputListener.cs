using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerInputListener : MonoBehaviour
{
    public static PlayerInputListener Instance;
    private PlayerMovement controller;

    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        this.controller = GetComponent<PlayerMovement>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed) {
            Vector2 movement = context.ReadValue<Vector2>();
            this.controller.OnMovementInput(movement.x);
        } else if (context.canceled) {
            this.controller.OnMovementInput(0f);
        }
    }
}