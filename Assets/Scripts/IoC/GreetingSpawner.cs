using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lix.IoC
{
  public class GreetingSpawner : MonoBehaviour
  {

    [Inject]
    private GreetingConsumer.Factory greetingConsumerFactory;

    public float TimeBetweenSpawns = 1f;
    private float TimeSinceLastSpawn = 0f;

    private void Update()
    {
      TimeSinceLastSpawn += Time.deltaTime;
      if (TimeSinceLastSpawn >= TimeBetweenSpawns)
      {
        TimeSinceLastSpawn = 0f;
        GreetingConsumer a = greetingConsumerFactory.Create();
      }
    }

  }
}