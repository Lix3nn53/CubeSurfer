using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private GameObject[] trackPrefab;
    private GameObject before; // -50
    private GameObject current; // 0
    private GameObject next; // 50

    private int index = 1;

    private void Awake() {
        this.current = this.trackPrefab[0];
        this.current.transform.position = new Vector3(0, 0, 0);
        this.next = this.trackPrefab[1];
        this.next.transform.position = new Vector3(50, 0, 0);
        this.before = this.trackPrefab[2];
        this.before.transform.position = new Vector3(-50, 0, 0);
    }
    
    void FixedUpdate()
    {
        Vector3 position = PlayerMovement.Instance.transform.position;
        float distance = position.x;

        if (distance > 50) {
            PlayerMovement.Instance.transform.position = new Vector3(0, position.y, position.z);
            this.before = this.current;
            this.before.transform.position = new Vector3(-50, 0, 0);
            this.current = this.next;
            this.current.transform.position = new Vector3(0, 0, 0);

            if (index == trackPrefab.Length - 1) {
                index = 0;
            } else {
                index++;
            }

            this.next = this.trackPrefab[index];
            this.next.transform.position = new Vector3(50, 0, 0);
        }
    }
}
