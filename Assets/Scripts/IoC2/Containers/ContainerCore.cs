using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.CubeRunner;

public class ContainerCore : DIContainerRegisterMono
{
  [SerializeField] private InputListener inputListener;

  public override void RegisterDependencies(DIContainer builder)
  {
    builder.Register(new ServiceDescriptor(inputListener, ServiceLifetime.Singleton));
  }
}
