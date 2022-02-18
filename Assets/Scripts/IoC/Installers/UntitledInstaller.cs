using UnityEngine;
using Zenject;

namespace Lix.IoC
{
  [CreateAssetMenu(fileName = "UntitledInstaller", menuName = "Installers/UntitledInstaller")]
  public class UntitledInstaller : ScriptableObjectInstaller<UntitledInstaller>
  {
    public override void InstallBindings()
    {
    }
  }
}