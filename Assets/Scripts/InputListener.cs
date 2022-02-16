using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : Singleton<InputListener>
{

  private PlayerInput playerInput;
  public InputAction ActionMove;

  protected override void Awake()
  {
    base.Awake();
    playerInput = GetComponent<PlayerInput>();

    ActionMove = playerInput.currentActionMap.FindAction("Move");
  }
}