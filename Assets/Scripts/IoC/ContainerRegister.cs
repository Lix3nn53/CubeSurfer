using UnityEngine;
using Autofac;

namespace Lix.IoC
{

  public abstract class ContainerRegister : MonoBehaviour
  {
    public virtual void RegisterDependencies(ContainerBuilder builder)
    {
      throw new System.NotImplementedException();
    }
  }
}