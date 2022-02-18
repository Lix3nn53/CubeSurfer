using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.CubeRunner
{
  public class GameStatePause : IState
  {
    public void Enter()
    {
      Pause();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
      Resume();
    }

    public void Pause()
    {
      Time.timeScale = 0f;
      PauseMenu.Instance.PauseMenuPanel.SetActive(true);
    }

    public void Resume()
    {
      Time.timeScale = 1f;
      PauseMenu.Instance.PauseMenuPanel.SetActive(false);
    }
  }
}