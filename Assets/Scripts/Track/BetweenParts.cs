using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenParts : MonoBehaviour
{
  public void generate(float start, float end, float z)
  {
    for (float cubeX = start; cubeX < end; cubeX += TrackManager.Instance.CubeLength + TrackManager.Instance.CubeDistanceBetween)
    {
      int randomHeight = UnityEngine.Random.Range(1, 4);

      for (int i = 1; i <= randomHeight; i++)
      {
        // Cube cube = Instantiate(TrackManager.Instance.CubePrefab, new Vector3(cubeX, i, z), Quaternion.identity, transform).GetComponent<Cube>();
        CubePool cubePool = CubePool.Instance;
        GameObject cube = cubePool.Pool.Get();
        cube.transform.SetParent(this.transform);
        cube.transform.position = new Vector3(cubeX, i, z);
      }
    }
  }

  public void returnCubesAndDestroySelf()
  {
    GameObject[] cubes = new GameObject[transform.childCount];
    for (int i = 0; i < transform.childCount; i++)
    {
      cubes[i] = transform.GetChild(i).gameObject;
    }
    for (int i = 0; i < cubes.Length; i++)
    {
      // Destroy(this.DroppedCubeThrash.transform.GetChild(i).gameObject);
      CubePool.Instance.Pool.Release(cubes[i]);
    }

    Destroy(this.gameObject);
  }
}
