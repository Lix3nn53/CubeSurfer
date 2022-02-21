using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.CubeRunner;

namespace Lix.IoC
{
  public class ContainerUI : IContainerRegister
  {
    [SerializeField] private PauseMenu pauseMenu;

    public void Register(ContainerBuilder builder)
    {
      builder.RegisterInstance(pauseMenu).As<PauseMenu>().SingleInstance();

      DependencyResolver.Container = builder.Build();
    }
  }
}