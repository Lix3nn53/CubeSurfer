using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Triggerable
{
    public override void OnTrigger(Collider other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        int offsetFromGround = (int) (this.gameObject.transform.parent.localPosition.y);
        int height = (int) (this.gameObject.transform.parent.localScale.y + 0.5f);

        PlayerCollider.Instance.OnObstacle(offsetFromGround, height);
    }
}
