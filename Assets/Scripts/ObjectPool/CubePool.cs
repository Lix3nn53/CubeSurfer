using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : GameObjectPool
{
    public static CubePool Instance;

    public new void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        
        base.Awake();
        Debug.Log("POOL AWAKE 2");
    }

    public new GameObject Get()
    {
        GameObject gameObject = base.Get();
        gameObject.AddComponent<Cube>();

        return gameObject;
    }
}
