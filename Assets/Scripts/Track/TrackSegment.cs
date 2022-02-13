using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    public GameObject DroppedCubeThrash;
    private int partEveryLength;
    private int partOffset;
    private int partCount;

    private SegmentPart[] segmentParts;

    // BetweenParts
    private BetweenParts[] betweenPartsArray;

    private void clear()
    {
        if (segmentParts == null) return;
        
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
        for (int i = 0; i < this.DroppedCubeThrash.transform.childCount; i++) {
            Destroy(this.DroppedCubeThrash.transform.GetChild(i).gameObject);
        }
    }

    private void randomize()
    {
        partCount = UnityEngine.Random.Range(2, 4);
        partEveryLength = (int) TrackManager.Instance.SegmentLength / partCount;
        partOffset = (int) TrackManager.Instance.SegmentLength % partCount;

        segmentParts = new SegmentPart[partCount];
        betweenPartsArray = new BetweenParts[partCount + 1];
    }

    private void generate()
    {
        float previousX = transform.position.x;

        for (int i = 0; i < partCount; i++)
        {
            float x = transform.position.x + (i * partEveryLength) + partOffset;

            SegmentPart segmentPart = Instantiate(TrackManager.Instance.SegmentPartPrefab, new Vector3(x, 0, 0), Quaternion.identity).GetComponent<SegmentPart>();
            segmentPart.transform.parent = transform;
            segmentParts[i] = segmentPart;

            BetweenParts betweenParts = Instantiate(TrackManager.Instance.BetweenPartsPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<BetweenParts>();
            betweenParts.transform.parent = transform;
            betweenParts.generate(previousX + TrackManager.Instance.CubeDistanceBetween, x, UnityEngine.Random.Range(0, 5));
            betweenPartsArray[i] = betweenParts;

            previousX = x;
        }

        // Cubes from last part until end of segment
        BetweenParts betweenPartss = Instantiate(TrackManager.Instance.BetweenPartsPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<BetweenParts>();
        betweenPartss.transform.parent = transform;
        betweenPartss.generate(previousX + TrackManager.Instance.CubeDistanceBetween, transform.position.x + TrackManager.Instance.SegmentLength, UnityEngine.Random.Range(0, 5));
        betweenPartsArray[partCount] = betweenPartss;
    }

    public void OnStart() {
        randomize();
        generate();
    }

    public void OnRestart() {
        clear();
        randomize();
        generate();
    }
}
