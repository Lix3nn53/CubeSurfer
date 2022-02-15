using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
  public static Dictionary<string, GameObjectPool> PoolDict = new Dictionary<string, GameObjectPool>();

  public static GameObjectPool Get(string poolName)
  {
    return PoolDict[poolName];
  }

  public static void Add(string poolName, GameObjectPool pool)
  {
    PoolDict.Add(poolName, pool);
  }
}
