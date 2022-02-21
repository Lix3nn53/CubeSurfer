using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.CubeRunner;
using Autofac;

[CreateAssetMenu(menuName = "IoC/BootstrapperSettings")]
public class BootstrapperSettings : ScriptableObject
{
  [SerializeField] private InputListener inputListener;
  [SerializeField] private PlayerCollider playerCollider;
  [SerializeField] private PlayerMovement playerMovement;
  [SerializeField] private TrackManager trackManager;
  [SerializeField] private PauseMenu pauseMenu;

  public void InstallBindings(ContainerBuilder builder)
  {
    builder.RegisterType<Hello>().As<IHello>();
    // builder.RegisterType<Hello>().As<IHello>().SingleInstance();

    builder.RegisterInstance(inputListener).As<IInputListener>().SingleInstance();

    builder.RegisterInstance(playerCollider).As<PlayerCollider>().SingleInstance();

    builder.RegisterInstance(playerMovement).As<PlayerMovement>().SingleInstance();

    builder.RegisterInstance(trackManager).As<TrackManager>().SingleInstance();

    builder.RegisterInstance(pauseMenu).As<PauseMenu>().SingleInstance();
  }
}
