using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    private static int partEveryLength = 18;
    private static int partOffset;
    private int partCount;

    private SegmentPart[] segmentParts;

    // BetweenParts
    private BetweenParts[] betweenPartsArray;

    private void Start() {
        partCount = (int) TrackManager.Instance.SegmentLength / partEveryLength;
        segmentParts = new SegmentPart[partCount];

        partOffset = (((int) TrackManager.Instance.SegmentLength) - (partCount * partEveryLength)) / partCount;

        betweenPartsArray = new BetweenParts[partCount + 1];

        generate();
    }

    private void clear()
    {
        for (int i = 0; i < segmentParts.Length; i++) {
            if (segmentParts[i] == null) {
                continue;
            }

            Destroy(segmentParts[i].gameObject);
        }

        // remove uncollected cubes
        for (int i = 0; i < betweenPartsArray.Length; i++) {
            if (betweenPartsArray[i] == null) {
                continue;
            }

            Destroy(betweenPartsArray[i].gameObject);
        }

        // remove cubes dropped from player
        for (int i = 0; i < GameManager.Instance.CubeThrash.transform.childCount; i++) {
            Destroy(GameManager.Instance.CubeThrash.transform.GetChild(i).gameObject);
        }
    }

    private void generate()
    {
        float previousX = transform.position.x;

        for (int i = 0; i < partCount; i++)
        {
            float x = transform.position.x + (i * partEveryLength) + partOffset;

            SegmentPart segmentPart = Instantiate(TrackManager.Instance.SegmentPartPrefab, new Vector3(x, 0, 0), Quaternion.identity).GetComponent<SegmentPart>();
            segmentPart.transform.parent = transform;

            BetweenParts betweenParts = Instantiate(TrackManager.Instance.BetweenPartsPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<BetweenParts>();
            betweenParts.transform.parent = transform;
            betweenParts.generate(previousX + TrackManager.Instance.CubeDistanceBetween, x);
            betweenPartsArray[i] = betweenParts;

            previousX = x;
        }

        // Cubes from last part until end of segment
        BetweenParts betweenPartss = Instantiate(TrackManager.Instance.BetweenPartsPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<BetweenParts>();
        betweenPartss.transform.parent = transform;
        betweenPartss.generate(previousX + TrackManager.Instance.CubeDistanceBetween, transform.position.x + TrackManager.Instance.SegmentLength);
        betweenPartsArray[partCount] = betweenPartss;
    }

    public void OnRestart() {
        clear();
        generate();
    }
}
