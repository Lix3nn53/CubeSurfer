using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using Lix.CubeRunner;

public class ContainerGame : DIContainerRegisterMono
{
  [SerializeField] private PlayerCollider playerCollider;
  [SerializeField] private PlayerMovement playerMovement;
  [SerializeField] private TrackManager trackManager;

  public override void RegisterDependencies(IDIContainer container)
  {
    container.Register(new ServiceDescriptor(playerCollider, ServiceLifetime.Singleton));

    container.Register(new ServiceDescriptor(playerMovement, ServiceLifetime.Singleton));

    container.Register(new ServiceDescriptor(trackManager, ServiceLifetime.Singleton));
  }
}
