using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using Lix.CubeRunner;

public class ContainerUI : DIContainerRegisterMono
{
  [SerializeField] private PauseMenu pauseMenu;

  public override void RegisterDependencies(IDIContainer container)
  {
    container.Register(new ServiceDescriptor(pauseMenu, ServiceLifetime.Singleton));
  }
}
