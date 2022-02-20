using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lix.IoC
{
  public class GreetingInstaller : MonoInstaller<GreetingInstaller>
  {

    [Inject]
    private GameSettings gameSettings;

    public override void InstallBindings()
    {
      // Container.Bind<IGreeting>().To<Greeting>().AsSingle().NonLazy();
      // Container.Bind<IGreeting>().To<Greeting>().FromFactory<Greeting.Factory>().AsSingle().NonLazy();
      Container.Bind<IGreeting>().To<Greeting>().AsSingle().WithArguments("WITH ARGUMENTS").NonLazy();

      Container.BindFactory<GreetingConsumer, GreetingConsumer.Factory>().FromComponentInNewPrefab(gameSettings.greetingConsumerPrefab);
    }
  }
}