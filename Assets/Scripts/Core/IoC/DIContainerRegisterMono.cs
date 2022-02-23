using UnityEngine;

namespace Lix.Core
{
  public abstract class DIContainerRegisterMono : MonoBehaviour, IDIContainerRegister
  {
    private void Awake()
    {
      RegisterDependencies(DIContainer.Instance);
    }

    public abstract void RegisterDependencies(IDIContainer container);
  }
}