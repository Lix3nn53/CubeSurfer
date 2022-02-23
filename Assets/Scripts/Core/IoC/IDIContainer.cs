using System;
using System.Linq;
using System.Collections.Generic;

namespace Lix.Core
{
  public interface IDIContainer
  {
    public IDictionary<Type, ServiceDescriptor> GetServiceDescriptors()
    {
      throw new NotImplementedException();
    }

    public void Register(ServiceDescriptor serviceDescriptor)
    {
      IDictionary<Type, ServiceDescriptor> serviceDescriptors = GetServiceDescriptors();

      serviceDescriptors[serviceDescriptor.ServiceType] = serviceDescriptor;
    }

    public object GetService(Type serviceType)
    {
      IDictionary<Type, ServiceDescriptor> serviceDescriptors = GetServiceDescriptors();
      var serviceDescriptor = serviceDescriptors[serviceType];

      if (serviceDescriptor == null)
      {
        throw new Exception($"Service of type {serviceType.Name} is not registered");
      }

      // Return implementation if it is already created
      if (serviceDescriptor.Implementation != null)
      {
        return serviceDescriptor.Implementation;
      }

      // Create implementation if it is not created yet
      Type actualType = serviceDescriptor.ImplementationType ?? serviceDescriptor.ServiceType;
      if (actualType.IsAbstract || actualType.IsInterface)
      {
        throw new Exception($"Can't create instance of abstract or interface type {actualType.Name}");
      }

      System.Reflection.ConstructorInfo constructorInfo = actualType.GetConstructors()[0];

      object[] parameters = constructorInfo.GetParameters().Select(parameter => GetService(parameter.ParameterType)).ToArray();

      var implementation = Activator.CreateInstance(actualType, parameters); // constructorInfo.Invoke(parameters); 

      // Save implementation if it is singleton
      if (serviceDescriptor.ServiceLifetime == ServiceLifetime.Singleton)
      {
        serviceDescriptor.Implementation = implementation;
      }

      return implementation;
    }

    public T GetService<T>()
    {
      return (T)GetService(typeof(T));
    }
  }
}