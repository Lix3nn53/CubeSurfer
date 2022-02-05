using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Collectable
{

    public override void OnCollect(Collider other) {
        Debug.Log("AAAAAAAAAA");
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        CubeCollector.Instance.OnCollect(this.gameObject);
    }
}
