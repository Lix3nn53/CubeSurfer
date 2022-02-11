using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private GameObject[] trackPrefab;
    [SerializeField] private float trackLength = 100;

    GameObject[] array = new GameObject[6];

    private void Awake() {
        this.array[0] = this.trackPrefab[0];
        this.array[0].transform.position = new Vector3(-trackLength, 0, 0);
        this.array[1] = this.trackPrefab[1];
        this.array[1].transform.position = new Vector3(0, 0, 0);
        this.array[2] = this.trackPrefab[2];
        this.array[2].transform.position = new Vector3(trackLength, 0, 0);
        this.array[3] = this.trackPrefab[3];
        this.array[3].transform.position = new Vector3(trackLength * 2, 0, 0);
        this.array[4] = this.trackPrefab[4];
        this.array[4].transform.position = new Vector3(trackLength * 3, 0, 0);
        this.array[5] = this.trackPrefab[5];
        this.array[5].transform.position = new Vector3(trackLength * 4, 0, 0);
    }
    
    void FixedUpdate()
    {
        Vector3 position = PlayerMovement.Instance.transform.position;
        float distance = position.x;

        if (distance > trackLength) {
            PlayerMovement.Instance.transform.position = new Vector3(0, position.y, position.z);

            GameObject temp = this.array[0];

            this.array[0] = this.array[1];
            this.array[0].transform.position = new Vector3(-trackLength, 0, 0);
            this.array[1] = this.array[2];
            this.array[1].transform.position = new Vector3(0, 0, 0);
            this.array[2] = this.array[3];
            this.array[2].transform.position = new Vector3(trackLength, 0, 0);
            this.array[3] = this.array[4];
            this.array[3].transform.position = new Vector3(trackLength * 2, 0, 0);
            this.array[4] = this.array[5];
            this.array[4].transform.position = new Vector3(trackLength * 3, 0, 0);

            this.array[5] = temp;
            this.array[5].transform.position = new Vector3(trackLength * 4, 0, 0);
        }
    }
}
