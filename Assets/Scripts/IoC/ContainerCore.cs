using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using Lix.CubeRunner;

public class ContainerCore : DIContainerRegisterMono
{
  [SerializeField] private InputListener inputListener;

  public override void RegisterDependencies(IDIContainer container)
  {
    container.Register(new ServiceDescriptor(inputListener, typeof(IInputListener), ServiceLifetime.Singleton));
  }
}
