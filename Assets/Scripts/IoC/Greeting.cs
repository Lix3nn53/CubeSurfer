using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lix.IoC
{
  public class Greeting : IGreeting
  {
    private string name = "Lix3nn";

    public Greeting(string name)
    {
      this.name = name;
    }

    public void Greet(GameObject gameObject)
    {
      Debug.Log("Hello " + name + "!", gameObject);
    }

    public class Factory : IFactory<Greeting>
    {
      public Greeting Create()
      {
        return new Greeting("ZENJECT FACTORY");
      }
    }
  }
}