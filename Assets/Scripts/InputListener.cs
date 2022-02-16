using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : Singleton<InputListener>
{

  // todo delegate
  public delegate void OnMovementInput(InputAction.CallbackContext context);

  public event OnMovementInput OnMovement;

  public void OnMovementAction(InputAction.CallbackContext context)
  {
    if (OnMovement != null)
    {
      OnMovement(context);
    }
  }
}