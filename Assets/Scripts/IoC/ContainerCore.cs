using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.CubeRunner;

namespace Lix.IoC
{
  public class ContainerCore : MonoBehaviour
  {
    [SerializeField] private InputListener inputListener;

    void Awake()
    {
      ContainerBuilder builder = new ContainerBuilder();

      builder.RegisterInstance(inputListener).As<IInputListener>().SingleInstance();

      DependencyResolver.ContainerCore = builder.Build();
    }
  }
}