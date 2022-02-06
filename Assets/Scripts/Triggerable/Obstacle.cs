using System;
using UnityEngine;

public class Obstacle : Triggerable
{
    [Serializable]
    public struct ObstaclePart
    {
        public int start;
        public int height;
    }

    [SerializeField] private ObstaclePart[] parts = {};

    public override void OnTrigger(Collider other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        PlayerCollider.Instance.OnObstacle(parts);
    }
}
