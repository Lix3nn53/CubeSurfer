using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lix.IoC
{
  public class GreetingConsumer : MonoBehaviour
  {
    public bool IsGoodbye = false;
    private IGreeting greeting;

    [Inject]
    private void Init(IGreeting greeting)
    {
      this.greeting = greeting;
    }

    private void Update()
    {
      if (IsGoodbye)
      {
        Debug.Log("Goodbye!", gameObject);
      }
      else
      {
        greeting.Greet(gameObject);
      }
    }

    public class Factory : PlaceholderFactory<GreetingConsumer>
    {
    }
  }


}