using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceDescriptor
{
  public Type ServiceType { get; set; }
  public Type ImplementationType { get; set; }
  public ServiceLifetime ServiceLifetime { get; set; }
  public object Implementation { get; set; }
  public ServiceDescriptor(object implementation, ServiceLifetime lifetime)
  {
    this.ServiceType = implementation.GetType();
    this.Implementation = implementation;
    this.ServiceLifetime = lifetime;
  }
  public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
  {
    this.ServiceType = serviceType;
    this.ServiceLifetime = lifetime;
  }
  public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
  {
    this.ServiceType = serviceType;
    this.ImplementationType = implementationType;
    this.ServiceLifetime = lifetime;
  }
}
