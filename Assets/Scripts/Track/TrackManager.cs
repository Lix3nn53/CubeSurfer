using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public static float SegmentLength = 50;
    private TrackSegment[] segmentPrefabs;

    private TrackSegment[] segmentBuffer;

    private void Awake() {
        // Init prefabs
        this.segmentPrefabs = new TrackSegment[transform.childCount];
        for (int i = 0; i < segmentPrefabs.Length; i++) {
            Transform segment = transform.GetChild(i);

            this.segmentPrefabs[i] = segment.GetComponent<TrackSegment>();
        }

        // Init buffer
        this.segmentBuffer = new TrackSegment[segmentPrefabs.Length];

        for (int i = 0; i < segmentBuffer.Length; i++) {
            this.segmentBuffer[i] = this.segmentPrefabs[i];

            this.segmentBuffer[i].transform.position = new Vector3(-SegmentLength + (i * SegmentLength), 0, 0);
        }
    }
    
    void FixedUpdate()
    {
        Vector3 position = PlayerMovement.Instance.transform.position;
        float distance = position.x;

        if (distance > SegmentLength) {
            PlayerMovement.Instance.transform.position = new Vector3(0, position.y, position.z);

            TrackSegment temp = this.segmentBuffer[0];

            for (int i = 0; i < segmentBuffer.Length - 1; i++) {
                this.segmentBuffer[i] = this.segmentBuffer[i + 1];

                this.segmentBuffer[i].transform.position = new Vector3(-SegmentLength + (i * SegmentLength), 0, 0);
            }

            this.segmentBuffer[segmentBuffer.Length - 1] = temp;
            this.segmentBuffer[segmentBuffer.Length - 1].transform.position = new Vector3(-SegmentLength + (SegmentLength * (segmentBuffer.Length - 1)), 0, 0);
        }
    }
}
