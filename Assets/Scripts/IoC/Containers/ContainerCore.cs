using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.CubeRunner;

namespace Lix.IoC
{
  public class ContainerCore : ContainerRegister
  {
    [SerializeField] private InputListener inputListener;

    public override void RegisterDependencies(ContainerBuilder builder)
    {
      builder.RegisterInstance(inputListener).As<IInputListener>().SingleInstance();
    }
  }
}