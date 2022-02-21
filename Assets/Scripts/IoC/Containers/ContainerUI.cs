using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.CubeRunner;

namespace Lix.IoC
{
  public class ContainerUI : ContainerRegister
  {
    [SerializeField] private PauseMenu pauseMenu;

    public override void RegisterDependencies(ContainerBuilder builder)
    {
      builder.RegisterInstance(pauseMenu).As<PauseMenu>().SingleInstance();
    }
  }
}