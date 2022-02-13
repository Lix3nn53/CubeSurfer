using System;
using System.Linq;
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
        // Container Height
        float containerY = this.graphicsContainer.transform.position.y + this.heightPerCube + 0.2f;
        this.graphicsContainer.transform.position = new Vector3(this.graphicsContainer.transform.position.x, containerY, this.graphicsContainer.transform.position.z);

        // Add New Cube To Container
        cube.transform.parent = this.cubeContainer.gameObject.transform;
        float localY = cubes[cubes.Count - 1].transform.localPosition.y - this.heightPerCube;
        cube.transform.localPosition = new Vector3(0, localY, 0);
        this.cubes.Add(cube);

        // PlayerGraphics Height
        float playerGraphicsY = this.playerGraphics.transform.localPosition.y + this.jumpOnCollect;
        this.playerGraphics.transform.localPosition = new Vector3(this.playerGraphics.transform.localPosition.x, playerGraphicsY, this.playerGraphics.transform.localPosition.z);
        
        // Player player = go.GetComponent<Player>();

        // player.SetSelectedInterractable(this);

        // AudioManager.Instance.Play("interractEnter");
    }
    public void OnObstacle(ObstacleGroup.ObstacleLine[] parts) {
        List<int> toRemove = new List<int>();
        foreach (ObstacleGroup.ObstacleLine part in parts)
        {
            for (int i = part.start; i < part.start + part.height; i++) {
                toRemove.Add(i);
            }
        }

        // Remove cubes from player
        if (toRemove.Count > 1) {
            toRemove = toRemove.Distinct().ToList();
            toRemove.Sort();
        }

        // Check for gameover
        int count = this.cubes.Count;
        if (count <= toRemove.Count) {
            PlayerMovement.Instance.StopRunning();
            Debug.Log("GAME OVER");
            return;
        }

        int lastIndex = count - 1;
        foreach (int i in toRemove) {
            GameObject cubeToRemove = this.cubes[lastIndex - i];
            cubeToRemove.transform.parent = TrackManager.Instance.GetCurrentSegment().DroppedCubeThrash.transform; // Add dropped cube to thrash of current segment
            cubeToRemove.transform.localPosition = new Vector3((int) (cubeToRemove.transform.localPosition.x + 0.5f), cubeToRemove.transform.localPosition.y, cubeToRemove.transform.localPosition.z);
            this.cubes.RemoveAt(lastIndex - i);
        }
    }
}
