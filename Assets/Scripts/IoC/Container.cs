using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;

namespace Lix.IoC
{

  public class Container : MonoBehaviour
  {
    [SerializeReference] private IContainerRegister[] containerRegisters;
    private void Awake()
    {
      ContainerBuilder builder = new ContainerBuilder();

      foreach (IContainerRegister containerRegister in containerRegisters)
      {
        containerRegister.RegisterDependencies(builder);
      }

      DependencyResolver.Container = builder.Build();
    }
  }
}