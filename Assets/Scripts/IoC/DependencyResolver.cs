using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;

namespace Lix.IoC
{
  public static class DependencyResolver
  {
    public static IContainer ContainerCore { get; set; }
    public static IContainer ContainerUI { get; set; }
    public static IContainer ContainerGame { get; set; }
  }
}