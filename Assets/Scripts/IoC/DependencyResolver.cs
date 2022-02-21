using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;

namespace Lix.IoC
{
  public static class DependencyResolver
  {
    public static IContainer Container { get; set; }
  }
}