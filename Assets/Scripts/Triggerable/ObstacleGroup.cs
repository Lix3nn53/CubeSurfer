using System;
using UnityEngine;

public class ObstacleGroup : Triggerable
{
  private static float hitBoxWidth = 0.9f;

  [Serializable]
  public struct ObstacleLine
  {
    public int start;
    public int height;
  }

  [SerializeField] private ObstacleLine[][] lines;

  public override void OnTrigger(Collider other)
  {
    var go = other.gameObject;
    if (go == null || !other.gameObject.CompareTag("Player"))
      return;

    float line = PlayerMovement.Instance.gameObject.transform.localPosition.z;

    int indexMin = (int)(line);
    int indexMax = (int)(line + hitBoxWidth);

    ObstacleLine[] parts;
    if (indexMin < 0)
    {
      parts = lines[indexMax];
    }
    else if (indexMax > 4)
    {
      parts = lines[indexMin];
    }
    else
    {
      ObstacleLine[] x = lines[indexMin];
      ObstacleLine[] y = lines[indexMax];

      parts = new ObstacleLine[x.Length + y.Length];
      x.CopyTo(parts, 0);
      y.CopyTo(parts, x.Length);
    }

    PlayerCollider.Instance.OnObstacle(parts);
  }

  void Awake()
  {
    RandomShape();
    // AutoFillLineData(); // Random Shape already fills the data
  }

  //   private void AutoFillLineData()
  //   {
  //     lines = new ObstacleLine[5][];
  //     for (int i = 0; i < 5; i++)
  //     {
  //       Transform obstacleLine = transform.GetChild(i);
  //       int lineIndex = (int)obstacleLine.localPosition.z + 2;

  //       int obstacleCount = obstacleLine.childCount;
  //       lines[i] = new ObstacleLine[obstacleCount];
  //       for (int y = 0; y < obstacleCount; y++)
  //       {
  //         Transform obstacle = obstacleLine.GetChild(y);

  //         ObstacleLine obstaclePart = new ObstacleLine() { start = (int)obstacle.localPosition.y, height = (int)obstacle.localScale.y };
  //         lines[i][y] = obstaclePart;
  //       }
  //     }
  //   }

  public void RandomShape()
  {
    lines = new ObstacleLine[5][]; // Save data
    for (int i = 0; i < 5; i++)
    {
      Transform obstacleLine = transform.GetChild(i);

      int obstacleCount = UnityEngine.Random.Range(0, 4);
      lines[i] = new ObstacleLine[obstacleCount]; // Save data

      float startHeight = TrackManager.Instance.ObstacleStartHeight;
      for (int y = 0; y < obstacleCount; y++)
      {
        GameObject obstacle = ObstaclePool.Instance.Pool.Get();
        obstacle.transform.SetPositionAndRotation(new Vector3(0, startHeight, 0), Quaternion.identity);
        obstacle.transform.SetParent(obstacleLine);
        int obstacleHeight = UnityEngine.Random.Range(1, 3);
        obstacle.transform.localScale = new Vector3(1, obstacleHeight, 1);
        obstacle.transform.localPosition = new Vector3(0, startHeight, 0);

        // Save data
        ObstacleLine obstaclePart = new ObstacleLine() { start = (int)startHeight, height = obstacleHeight };
        lines[i][y] = obstaclePart;

        startHeight += obstacleHeight + 1;
      }
    }
  }
}
