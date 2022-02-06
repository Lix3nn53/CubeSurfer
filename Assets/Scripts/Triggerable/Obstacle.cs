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

    [SerializeField] private ObstaclePart[][] lines;

    public override void OnTrigger(Collider other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        ObstaclePart[] parts = lines[PlayerMovement.Instance.Line];

        PlayerCollider.Instance.OnObstacle(parts);
    }

    void Awake() {
        AutoFillLineData();
    }

    private void AutoFillLineData() {
        lines = new ObstaclePart[5][];
        for (int i = 0; i < 5; i++) {
            Transform obstacleLine = transform.GetChild(i);
            int lineIndex = (int) obstacleLine.localPosition.z + 2;

            int obstacleCount = obstacleLine.childCount;
            lines[i] = new ObstaclePart[obstacleCount];
            for (int y = 0; y < obstacleCount; y++) {
                Transform obstacle = obstacleLine.GetChild(y);

                ObstaclePart obstaclePart = new ObstaclePart() { start = (int) obstacle.localPosition.y, height = (int) obstacle.localScale.y };
                lines[i][y] = obstaclePart;
            }
        }
    }
}
