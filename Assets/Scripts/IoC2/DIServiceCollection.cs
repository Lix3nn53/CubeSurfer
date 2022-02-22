using System;
using System.Collections.Generic;
using UnityEngine;

public class DIServiceCollection
{
  private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();

  public DIContainer GenerateContainer()
  {
    return new DIContainer(_serviceDescriptors);
  }

  private int GetServiceDescriptorIndex(Type type)
  {
    for (int i = 0; i < _serviceDescriptors.Count; i++)
    {
      if (_serviceDescriptors[i].ServiceType == type)
      {
        return i;
      }
    }

    return -1;
  }

  public void RegisterSingleton<TService>(TService instance)
  {
    int index = GetServiceDescriptorIndex(typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(instance, ServiceLifetime.Singleton);
    if (index == -1)
    {
      _serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      _serviceDescriptors[index] = serviceDescriptor;
    }
  }

  public void RegisterSingleton<TService>()
  {
    int index = GetServiceDescriptorIndex(typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton);
    if (index == -1)
    {
      _serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      _serviceDescriptors[index] = serviceDescriptor;
    }
  }

  public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
  {
    int index = GetServiceDescriptorIndex(typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton);
    if (index == -1)
    {
      _serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      _serviceDescriptors[index] = serviceDescriptor;
    }
  }

  public void RegisterTransient<TService>()
  {
    int index = GetServiceDescriptorIndex(typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient);
    if (index == -1)
    {
      _serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      _serviceDescriptors[index] = serviceDescriptor;
    }
  }

  public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
  {
    int index = GetServiceDescriptorIndex(typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient);
    if (index == -1)
    {
      _serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      _serviceDescriptors[index] = serviceDescriptor;
    }
  }
}
