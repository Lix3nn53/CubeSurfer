using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenParts : MonoBehaviour
{
    public void generate(float start, float end, float z) {
        for (float cubeX = start; cubeX < end; cubeX += TrackManager.Instance.CubeLength + TrackManager.Instance.CubeDistanceBetween)
        {
            int randomHeight = UnityEngine.Random.Range(1, 4);

            for (int i = 1; i <= randomHeight; i++)
            {
                Cube cube = Instantiate(TrackManager.Instance.CubePrefab, new Vector3(cubeX, i, z), Quaternion.identity).GetComponent<Cube>();
                cube.transform.parent = transform;
            }
        }
    }
}
