using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    [SerializeField] private float speedForward = 200;
    [SerializeField] private float speedSideways = 300;

    private new Rigidbody rigidbody;
    private float movementInput;
    private bool isRunning = true;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
	{
        if (!isRunning) {
            return;
        }

        float sideWaysVelocity = movementInput * this.speedSideways * Time.deltaTime;
        float forwardVelocity =  this.speedForward * Time.deltaTime;

        rigidbody.velocity = new Vector3(-forwardVelocity, 0, sideWaysVelocity);
	}

    public void OnMovementInput(float movement) {
			this.movementInput = movement;
	}

    public void StopRunning() {
			this.isRunning = false;
            rigidbody.velocity = new Vector3(0, 0, 0);
	}
}
