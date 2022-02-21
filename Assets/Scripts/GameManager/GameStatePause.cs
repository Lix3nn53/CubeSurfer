using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using Autofac;
using Lix.IoC;

namespace Lix.CubeRunner
{
  public class GameStatePause : IState
  {
    private PauseMenu pauseMenu;

    public GameStatePause()
    {
      pauseMenu = DependencyResolver.Container.Resolve<PauseMenu>();
    }

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
      pauseMenu.PauseMenuPanel.SetActive(true);
    }

    public void Resume()
    {
      Time.timeScale = 1f;
      pauseMenu.PauseMenuPanel.SetActive(false);
    }
  }
}