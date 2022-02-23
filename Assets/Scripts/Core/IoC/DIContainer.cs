using System;
using System.Collections.Generic;

namespace Lix.Core
{
  public sealed class DIContainer : IDIContainer
  {
    #region Singleton
    private static IDIContainer instance = null;
    public static IDIContainer Instance
    {
      get
      {
        {
          if (instance == null)
          {
            instance = new DIContainer();
          }

          return instance;
        }
      }
    }
    #endregion

    private IDictionary<Type, ServiceDescriptor> serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();

    public IDictionary<Type, ServiceDescriptor> GetServiceDescriptors()
    {
      return serviceDescriptors;
    }
  }
}