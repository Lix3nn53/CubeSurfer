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

    [SerializeField] private ObstaclePart[] line0 = {};
    [SerializeField] private ObstaclePart[] line1 = {};
    [SerializeField] private ObstaclePart[] line2 = {};
    [SerializeField] private ObstaclePart[] line3 = {};
    [SerializeField] private ObstaclePart[] line4 = {};

    public override void OnTrigger(Collider other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        ObstaclePart[] parts;
        int line = PlayerMovement.Instance.Line;
        if (line == 0) {
            parts = line0;
        } else if (line == 1) {
            parts = line1;
        } else if (line == 2) {
            parts = line2;
        } else if (line == 3) {
            parts = line3;
        } else {
            parts = line4;
        }

        PlayerCollider.Instance.OnObstacle(parts);
    }
}
