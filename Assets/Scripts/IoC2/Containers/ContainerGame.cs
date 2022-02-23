using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.CubeRunner;

public class ContainerGame : DIContainerRegisterMono
{
  [SerializeField] private PlayerCollider playerCollider;
  [SerializeField] private PlayerMovement playerMovement;
  [SerializeField] private TrackManager trackManager;

  public override void RegisterDependencies(DIContainer builder)
  {
    builder.Register(new ServiceDescriptor(typeof(IHello), typeof(Hello), ServiceLifetime.Transient));

    builder.Register(new ServiceDescriptor(playerCollider, ServiceLifetime.Singleton));

    builder.Register(new ServiceDescriptor(playerMovement, ServiceLifetime.Singleton));

    builder.Register(new ServiceDescriptor(trackManager, ServiceLifetime.Singleton));
  }
}
