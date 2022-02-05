using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    public static CubeCollector Instance;
    [SerializeField] private int heightPerCube = 1;
    [SerializeField] private GameObject graphicsContainer;
    [SerializeField] private GameObject cubeContainer;
    [SerializeField] private GameObject playerGraphics;
    private int cubeCount = 1;

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
        graphicsContainer.transform.position = new Vector3(graphicsContainer.transform.position.x, graphicsContainer.transform.position.y + this.heightPerCube, graphicsContainer.transform.position.z);

        cube.transform.parent = cubeContainer.gameObject.transform;
        cube.transform.localPosition = new Vector3(0, -cubeCount, 0);
        cubeCount++;

        playerGraphics.transform.localPosition = new Vector3(playerGraphics.transform.localPosition.x, playerGraphics.transform.localPosition.y + 0.1f, playerGraphics.transform.localPosition.z);
        // Player player = go.GetComponent<Player>();

        // player.SetSelectedInterractable(this);

        // AudioManager.Instance.Play("interractEnter");
    }
}
