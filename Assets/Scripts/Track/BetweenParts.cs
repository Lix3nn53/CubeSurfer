using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenParts : MonoBehaviour
{
    public void generate(float start, float end) {
        for (float cubeX = start; cubeX < end; cubeX += TrackManager.Instance.CubeLength + TrackManager.Instance.CubeDistanceBetween)
        {
            Cube cube = Instantiate(TrackManager.Instance.CubePrefab, new Vector3(cubeX, 1, 0), Quaternion.identity).GetComponent<Cube>();
            cube.transform.parent = transform;
        }
    }
}
