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

        float line = PlayerMovement.Instance.gameObject.transform.localPosition.z;

        int indexMin = (int) (line);
        int indexMax = (int) (line + 0.9f);

        ObstaclePart[] parts;
        if (indexMin < 0) {
            parts = lines[indexMax];
        } else if (indexMax > 4) {
            parts = lines[indexMin];
        } else {
            ObstaclePart[] x = lines[indexMin];
            ObstaclePart[] y = lines[indexMax];

            parts = new ObstaclePart[x.Length + y.Length];
            x.CopyTo(parts, 0);
            y.CopyTo(parts, x.Length);
        }

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
