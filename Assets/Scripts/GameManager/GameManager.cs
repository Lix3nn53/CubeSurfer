using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : StateMachine
{
  private void Start()
  {
    ChangeState(new GameStatePlay());

    InputListener.Instance.ActionPause.performed += OnPauseInputPerformed;
  }

  private void OnPauseInputPerformed(InputAction.CallbackContext context)
  {

    if (CurrentState is GameStatePause)
    {
      ChangeState(new GameStatePlay());
    }
    else
    {
      ChangeState(new GameStatePause());
    }
  }

}
