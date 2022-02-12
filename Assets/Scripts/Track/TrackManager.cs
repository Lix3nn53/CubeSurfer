using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private GameObject[] trackPrefab;
    [SerializeField] private float trackLength = 100;

    private GameObject[] trackBuffer;

    private void Awake() {
        this.trackBuffer = new GameObject[trackPrefab.Length];

        for (int i = 0; i < trackBuffer.Length; i++) {
            this.trackBuffer[i] = this.trackPrefab[i];

            this.trackBuffer[i].transform.position = new Vector3(-this.trackLength + (i * this.trackLength), 0, 0);
        }
    }
    
    void FixedUpdate()
    {
        Vector3 position = PlayerMovement.Instance.transform.position;
        float distance = position.x;

        if (distance > trackLength) {
            PlayerMovement.Instance.transform.position = new Vector3(0, position.y, position.z);

            GameObject temp = this.trackBuffer[0];

            for (int i = 0; i < trackBuffer.Length - 1; i++) {
                this.trackBuffer[i] = this.trackBuffer[i + 1];

                this.trackBuffer[i].transform.position = new Vector3(-this.trackLength + (i * this.trackLength), 0, 0);
            }

            this.trackBuffer[trackBuffer.Length - 1] = temp;
            this.trackBuffer[trackBuffer.Length - 1].transform.position = new Vector3(-this.trackLength + (trackLength * (trackBuffer.Length - 1)), 0, 0);
        }
    }
}
