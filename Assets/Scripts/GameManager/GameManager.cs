using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;
using Autofac;
using Lix.IoC;

namespace Lix.CubeRunner
{
  public class GameManager : StateMachine
  {
    private void Start()
    {
      ChangeState(new GameStatePlay());

      IInputListener inputListener = DependencyResolver.ContainerCore.Resolve<IInputListener>();

      inputListener.GetAction(InputActionType.Pause).performed += OnPauseInputPerformed;
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
}