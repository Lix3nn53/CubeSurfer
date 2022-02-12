using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    private static int partEveryLength = 18;
    private int partCount;

    private SegmentPart[] segmentParts;

    private void Start() {
        partCount = (int) TrackManager.Instance.SegmentLength / partEveryLength;
        segmentParts = new SegmentPart[partCount];
    }

    private void clear()
    {
        for (int i = 0; i < segmentParts.Length; i++) {
            if (segmentParts[i] == null) {
                continue;
            }

            Destroy(segmentParts[i].gameObject);
        }
    }

    private void generate()
    {
        for (int i = 0; i < partCount; i++)
        {
            float x = transform.position.x + (i * partEveryLength);

            SegmentPart segmentPart = Instantiate(TrackManager.Instance.SegmentPartPrefab, new Vector3(x, 0, 0), Quaternion.identity).GetComponent<SegmentPart>();
            segmentPart.transform.parent = transform;
        }
    }

    public void OnRestart() {
        clear();
        generate();
    }
}
