using System;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

public class DIContainerMono : Singleton<DIContainerMono>, DIContainer
{
  [SerializeField] private List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor>();
  private IDictionary<Type, ServiceDescriptor> _serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();

  protected override void Awake()
  {
    base.Awake();

    foreach (var serviceDescriptor in serviceDescriptors)
    {
      ((DIContainer)this).Register(serviceDescriptor);
    }
  }

  public List<ServiceDescriptor> getServiceDescriptors()
  {
    return serviceDescriptors;
  }
}
