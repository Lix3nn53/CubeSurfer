using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.CubeRunner;

public class ContainerUI : DIContainerRegisterMono
{
  [SerializeField] private PauseMenu pauseMenu;

  public override void RegisterDependencies(DIContainer builder)
  {
    builder.Register(new ServiceDescriptor(pauseMenu, ServiceLifetime.Singleton));
  }
}
