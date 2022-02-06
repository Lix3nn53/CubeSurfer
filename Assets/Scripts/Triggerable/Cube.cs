using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Triggerable
{
    public override void OnTrigger(Collider other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        PlayerCollider.Instance.OnCube(this.gameObject);
        Destroy(this); // Removes this script instance from the game object
    }
}
