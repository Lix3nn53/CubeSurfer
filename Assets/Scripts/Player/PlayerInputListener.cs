using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputListener : Singleton<PlayerInputListener>
{
  private PlayerMovement controller;

  protected override void Awake()
  {
    base.Awake();
    this.controller = GetComponent<PlayerMovement>();
  }

  public void OnMovement(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      Vector2 movement = context.ReadValue<Vector2>();
      this.controller.OnMovementInput(movement.x);
    }
    else if (context.canceled)
    {
      this.controller.OnMovementInput(0f);
    }
  }
}