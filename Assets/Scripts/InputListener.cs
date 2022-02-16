using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : Singleton<InputListener>
{

  private PlayerInput playerInput;
  public InputAction ActionMove;
  public InputAction ActionPause;

  protected override void Awake()
  {
    base.Awake();
    playerInput = GetComponent<PlayerInput>();

    ActionMove = playerInput.currentActionMap.FindAction("Move");

    ActionPause = playerInput.currentActionMap.FindAction("Pause");
  }
}