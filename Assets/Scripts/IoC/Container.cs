using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.Core;

namespace Lix.IoC
{
  // Renamed from ContainerBuilder since Autofac already has a ContainerBuilder class.
  public class Container : MonoBehaviour
  {
    [SerializeReference] private ContainerRegister[] containerRegisters;
    private void Awake()
    {
      ContainerBuilder builder = new ContainerBuilder();

      foreach (ContainerRegister containerRegister in containerRegisters)
      {
        containerRegister.RegisterDependencies(builder);
      }

      DependencyResolver.Container = builder.Build();

      Destroy(gameObject); // Destroy the ContainerBuilder after building the container.
    }
  }
}