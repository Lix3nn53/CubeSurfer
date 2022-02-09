using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    Animator animator;

    void Awake() {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("SpeedY", Mathf.Abs(playerRb.velocity.y));
    }
}
