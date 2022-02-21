using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.IoC;

public class HelloConsumer : MonoBehaviour
{

  private IHello greeting;

  void Start()
  {
    greeting = DependencyResolver.Container.Resolve<IHello>();
  }

  // Update is called once per frame
  void Update()
  {
    greeting.SayHello("World");
  }
}
