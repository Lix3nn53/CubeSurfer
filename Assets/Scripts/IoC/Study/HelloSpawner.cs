using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;
using Lix.IoC;

public class HelloSpawner : MonoBehaviour
{
  public float TimeBetweenSpawns = 1f;
  private float TimeSinceLastSpawn = 0f;

  private void Update()
  {
    TimeSinceLastSpawn += Time.deltaTime;
    if (TimeSinceLastSpawn >= TimeBetweenSpawns)
    {
      TimeSinceLastSpawn = 0f;
      DependencyResolver.Container.Resolve<IHello>();
    }
  }
}
