using UnityEngine;
using Autofac;
using Lix.CubeRunner;

namespace Lix.IoC
{
  public class ContainerGame : MonoBehaviour
  {
    [SerializeField] private PlayerCollider playerCollider;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private TrackManager trackManager;

    private void Awake()
    {
      ContainerBuilder builder = new ContainerBuilder();

      builder.RegisterType<Hello>().As<IHello>();
      // builder.RegisterType<Hello>().As<IHello>().SingleInstance();

      builder.RegisterInstance(playerCollider).As<PlayerCollider>().SingleInstance();

      builder.RegisterInstance(playerMovement).As<PlayerMovement>().SingleInstance();

      builder.RegisterInstance(trackManager).As<TrackManager>().SingleInstance();

      DependencyResolver.ContainerGame = builder.Build();
    }
  }
}