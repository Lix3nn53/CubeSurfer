using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.CubeRunner;

namespace Lix.IoC
{
  public class ContainerUI : MonoBehaviour
  {
    [SerializeField] private PauseMenu pauseMenu;

    void Awake()
    {
      ContainerBuilder builder = new ContainerBuilder();

      builder.RegisterInstance(pauseMenu).As<PauseMenu>().SingleInstance();

      DependencyResolver.ContainerUI = builder.Build();
    }
  }
}