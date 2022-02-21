using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.CubeRunner;

namespace Lix.IoC
{
  public class ContainerCore : IContainerRegister
  {
    [SerializeField] private InputListener inputListener;

    public void Register(ContainerBuilder builder)
    {
      builder.RegisterInstance(inputListener).As<IInputListener>().SingleInstance();

      DependencyResolver.Container = builder.Build();
    }
  }
}