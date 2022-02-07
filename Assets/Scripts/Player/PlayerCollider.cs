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
        Debug.Log("localY: " + localY);
        cube.transform.localPosition = new Vector3(0, localY, 0);
        this.cubes.Add(cube);

        // PlayerGraphics Height
        float playerGraphicsY = this.playerGraphics.transform.localPosition.y + this.jumpOnCollect;
        this.playerGraphics.transform.localPosition = new Vector3(this.playerGraphics.transform.localPosition.x, playerGraphicsY, this.playerGraphics.transform.localPosition.z);
        
        // Player player = go.GetComponent<Player>();

        // player.SetSelectedInterractable(this);

        // AudioManager.Instance.Play("interractEnter");
    }
    public void OnObstacle(Obstacle.ObstaclePart[] parts) {
        List<int> toRemove = new List<int>();
        int requiredCount = 0;
        foreach (Obstacle.ObstaclePart part in parts)
        {
            int currentCount = part.start + part.height;
            if (currentCount > requiredCount) {
                requiredCount = currentCount;
            }

            for (int i = part.start; i < part.start + part.height; i++) {
                toRemove.Add(i);
            }
        }

        // Check for gameover
        int count = this.cubes.Count;
        if (count <= requiredCount) {
            PlayerMovement.Instance.StopRunning();
            return;
        }

        // Remove cubes from player
        if (toRemove.Count > 1) {
            toRemove = toRemove.Distinct().ToList();
            toRemove.Sort();
        }
        foreach(int x in toRemove) {
            Debug.Log("TOREMOVE: " + x);
        }
        int lastIndex = count - 1;
        foreach (int i in toRemove) {
            GameObject cubeToRemove = this.cubes[lastIndex - i];
            cubeToRemove.transform.parent = null;
            cubeToRemove.transform.localPosition = new Vector3((int) (cubeToRemove.transform.localPosition.x + 0.5f), cubeToRemove.transform.localPosition.y, cubeToRemove.transform.localPosition.z);
            Debug.Log(cubeToRemove.name);
            this.cubes.RemoveAt(lastIndex - i);
        }
    }
}
