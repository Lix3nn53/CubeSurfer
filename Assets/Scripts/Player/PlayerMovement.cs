using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedForward;
    [SerializeField] private float speedSideways;

    private new Rigidbody rigidbody;
    
    // PLAYER INPUTS
    private float movementInput;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
	{
        float sideWaysVelocity = movementInput * speedSideways * Time.deltaTime;
        float forwardVelocity =  speedForward * Time.deltaTime;

        rigidbody.velocity = new Vector3(-forwardVelocity, 0, sideWaysVelocity);
	}


    public void OnMovement(float movement) {
			this.movementInput = movement;
	}
}
