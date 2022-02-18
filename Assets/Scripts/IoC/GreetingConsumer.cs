using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lix.CubeRunner
{
  public class GreetingConsumer : MonoBehaviour
  {
    [Inject] private IGreeting greeting;

    private void Update()
    {
      greeting.Greet();
    }
  }
}