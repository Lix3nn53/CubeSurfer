using System;
using System.Collections.Generic;

public static class DIContainerBuilderUtils
{

  private static int GetServiceDescriptorIndex(List<ServiceDescriptor> serviceDescriptors, Type type)
  {
    for (int i = 0; i < serviceDescriptors.Count; i++)
    {
      if (serviceDescriptors[i].ServiceType == type)
      {
        return i;
      }
    }

    return -1;
  }

  public static DIContainer GenerateContainer(List<ServiceDescriptor> serviceDescriptors)
  {
    return new DIContainer(serviceDescriptors);
  }

  public static void RegisterSingleton<TService>(List<ServiceDescriptor> serviceDescriptors, TService instance)
  {
    int index = GetServiceDescriptorIndex(serviceDescriptors, typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(instance, ServiceLifetime.Singleton);
    if (index == -1)
    {
      serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      serviceDescriptors[index] = serviceDescriptor;
    }
  }

  public static void RegisterSingleton<TService>(List<ServiceDescriptor> serviceDescriptors)
  {
    int index = GetServiceDescriptorIndex(serviceDescriptors, typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton);
    if (index == -1)
    {
      serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      serviceDescriptors[index] = serviceDescriptor;
    }
  }

  public static void RegisterSingleton<TService, TImplementation>(List<ServiceDescriptor> serviceDescriptors) where TImplementation : TService
  {
    int index = GetServiceDescriptorIndex(serviceDescriptors, typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton);
    if (index == -1)
    {
      serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      serviceDescriptors[index] = serviceDescriptor;
    }
  }

  public static void RegisterTransient<TService>(List<ServiceDescriptor> serviceDescriptors)
  {
    int index = GetServiceDescriptorIndex(serviceDescriptors, typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient);
    if (index == -1)
    {
      serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      serviceDescriptors[index] = serviceDescriptor;
    }
  }

  public static void RegisterTransient<TService, TImplementation>(List<ServiceDescriptor> serviceDescriptors) where TImplementation : TService
  {
    int index = GetServiceDescriptorIndex(serviceDescriptors, typeof(TService));

    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient);
    if (index == -1)
    {
      serviceDescriptors.Add(serviceDescriptor);
    }
    else
    {
      serviceDescriptors[index] = serviceDescriptor;
    }
  }
}
