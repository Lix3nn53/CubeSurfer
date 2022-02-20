using UnityEngine;
using Zenject;

namespace Lix.IoC
{
  [CreateAssetMenu(fileName = "SettingInstaller", menuName = "Installers/SettingInstaller")]
  public class SettingInstaller : ScriptableObjectInstaller<SettingInstaller>
  {
    [SerializeField] private GameSettings gameSettings;
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(gameSettings).AsSingle().NonLazy();
    }
  }
}