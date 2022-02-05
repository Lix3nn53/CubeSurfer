using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    public static CubeCollector Instance;
    [SerializeField] private GameObject graphicsContainer;
    [SerializeField] private GameObject cubeContainer;
    [SerializeField] private GameObject playerGraphics;
    [SerializeField] private float heightPerCube = 1.0f;
    [SerializeField] private float jumpOnCollect = 0.2f;
    [SerializeField] private float distanceBetweenCubes = 0.1f;
    [SerializeField] private List<GameObject> cubes = new List<GameObject>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void OnCollect(GameObject cube) {
        int cubeCount = cubes.Count;

        // Container Height
        float containerY = graphicsContainer.transform.position.y + this.heightPerCube + distanceBetweenCubes;
        graphicsContainer.transform.position = new Vector3(graphicsContainer.transform.position.x, containerY, graphicsContainer.transform.position.z);

        // Add New Cube To Container
        cube.transform.parent = cubeContainer.gameObject.transform;
        float localY = -cubeCount - (distanceBetweenCubes * cubeCount);
        cube.transform.localPosition = new Vector3(0, localY, 0);
        cubes.Add(cube);

        // PlayerGraphics Height
        float playerGraphicsY = playerGraphics.transform.localPosition.y + jumpOnCollect;
        playerGraphics.transform.localPosition = new Vector3(playerGraphics.transform.localPosition.x, playerGraphicsY, playerGraphics.transform.localPosition.z);
        
        // Player player = go.GetComponent<Player>();

        // player.SetSelectedInterractable(this);

        // AudioManager.Instance.Play("interractEnter");
    }
    public void OnObstacle(int start, int height) {
        Debug.Log("START: " + start);
        Debug.Log("height: " + height);

        int lastIndex = cubes.Count - 1;
        for (int i = start; i < start + height; i++) {
            cubes[lastIndex - i].transform.parent = null;
            Debug.Log(cubes[lastIndex - i].name);
            cubes.RemoveAt(lastIndex - i);
        }
    }
}
