using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    public virtual void OnTriggerEnter(Collider other) {
        this.OnCollect(other);
    }

    public virtual void OnCollect(Collider other) {

    }
}