using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIContainerBuilder : IDIContainerBuilder
{
  private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();

  public DIContainer GenerateContainer()
  {
    return DIContainerBuilderUtils.GenerateContainer(_serviceDescriptors);
  }

  public void RegisterSingleton<TService>(TService instance)
  {
    DIContainerBuilderUtils.RegisterSingleton<TService>(_serviceDescriptors, instance);
  }

  public void RegisterSingleton<TService>()
  {
    DIContainerBuilderUtils.RegisterSingleton<TService>(_serviceDescriptors);
  }

  public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
  {
    DIContainerBuilderUtils.RegisterSingleton<TService, TImplementation>(_serviceDescriptors);
  }

  public void RegisterTransient<TService>()
  {
    DIContainerBuilderUtils.RegisterTransient<TService>(_serviceDescriptors);
  }

  public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
  {
    DIContainerBuilderUtils.RegisterTransient<TService, TImplementation>(_serviceDescriptors);
  }
}
