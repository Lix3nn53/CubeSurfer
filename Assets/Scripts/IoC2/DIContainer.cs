using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIContainer
{
  private IDictionary<Type, ServiceDescriptor> _serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();

  public DIContainer(List<ServiceDescriptor> serviceDescriptors)
  {
    foreach (var serviceDescriptor in serviceDescriptors)
    {
      _serviceDescriptors.Add(serviceDescriptor.ServiceType, serviceDescriptor);
    }
  }

  public object GetService(Type serviceType)
  {
    var decriptor = _serviceDescriptors[serviceType];

    if (decriptor == null)
    {
      throw new Exception($"Service of type {serviceType.Name} is not registered");
    }

    // Return implementation if it is already created
    if (decriptor.Implementation != null)
    {
      return decriptor.Implementation;
    }

    // Create implementation if it is not created yet
    Type actualType = decriptor.ImplementationType ?? decriptor.ServiceType;
    if (actualType.IsAbstract || actualType.IsInterface)
    {
      throw new Exception($"Can't create instance of abstract or interface type {actualType.Name}");
    }

    System.Reflection.ConstructorInfo constructorInfo = actualType.GetConstructors()[0];

    object[] parameters = constructorInfo.GetParameters().Select(parameter => GetService(parameter.ParameterType)).ToArray();

    var implementation = Activator.CreateInstance(actualType, parameters); // constructorInfo.Invoke(parameters); 

    // Save implementation if it is singleton
    if (decriptor.ServiceLifetime == ServiceLifetime.Singleton)
    {
      decriptor.Implementation = implementation;
    }

    return implementation;
  }

  public T GetService<T>()
  {
    return (T)GetService(typeof(T));
  }
}
