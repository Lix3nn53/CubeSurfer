using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The PlayerCollider handles what happens when the player collides with something.
/// 
/// The Player can collide with:
/// - Cube
/// - Obstacle
/// - Crystal
/// </summary>
public class PlayerCollider : MonoBehaviour
{
    public static PlayerCollider Instance;
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

    public void OnCube(GameObject cube) {
        int cubeCount = this.cubes.Count;

        // Container Height
        float containerY = this.graphicsContainer.transform.position.y + this.heightPerCube + this.distanceBetweenCubes;
        this.graphicsContainer.transform.position = new Vector3(this.graphicsContainer.transform.position.x, containerY, this.graphicsContainer.transform.position.z);

        // Add New Cube To Container
        cube.transform.parent = this.cubeContainer.gameObject.transform;
        float localY = -cubeCount - (this.distanceBetweenCubes * cubeCount);
        cube.transform.localPosition = new Vector3(0, localY, 0);
        this.cubes.Add(cube);

        // PlayerGraphics Height
        float playerGraphicsY = this.playerGraphics.transform.localPosition.y + this.jumpOnCollect;
        this.playerGraphics.transform.localPosition = new Vector3(this.playerGraphics.transform.localPosition.x, playerGraphicsY, this.playerGraphics.transform.localPosition.z);
        
        // Player player = go.GetComponent<Player>();

        // player.SetSelectedInterractable(this);

        // AudioManager.Instance.Play("interractEnter");
    }
    public void OnObstacle(int start, int height) {
        Debug.Log("START: " + start);
        Debug.Log("height: " + height);

        // Check for gameover
        int total = start + height;
        int count = this.cubes.Count;
        int requiredCount = total;
        if (count <= requiredCount) {
            PlayerMovement.Instance.StopRunning();
            return;
        }

        // Remove cubes from player
        int lastIndex = count - 1;
        for (int i = start; i < total; i++) {
            this.cubes[lastIndex - i].transform.parent = null;
            Debug.Log(this.cubes[lastIndex - i].name);
            this.cubes.RemoveAt(lastIndex - i);
        }
    }
}
