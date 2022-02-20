using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.CubeRunner;

public class Bootstrapper : MonoBehaviour
{
  [SerializeField] private InputListener inputListener;
  [SerializeField] private PlayerCollider playerCollider;
  [SerializeField] private PlayerMovement playerMovement;
  [SerializeField] private TrackManager trackManager;
  [SerializeField] private PauseMenu pauseMenu;



  private void Awake()
  {
    var builder = new ContainerBuilder();

    builder.RegisterType<Hello>().As<IHello>();
    // builder.RegisterType<Hello>().As<IHello>().SingleInstance();

    builder.RegisterInstance(inputListener).As<IInputListener>().SingleInstance();

    builder.RegisterInstance(playerCollider).As<PlayerCollider>().SingleInstance();

    builder.RegisterInstance(playerMovement).As<PlayerMovement>().SingleInstance();

    builder.RegisterInstance(trackManager).As<TrackManager>().SingleInstance();

    builder.RegisterInstance(pauseMenu).As<PauseMenu>().SingleInstance();

    DependencyResolver.Container = builder.Build();
  }
}
