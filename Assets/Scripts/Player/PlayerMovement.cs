using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    [SerializeField] private float speedForward = 200;
    [SerializeField] private float speedSideways = 300;
    private new Rigidbody rigidbody;
    private bool isRunning = true;

    private float movementInput;

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

        float forwardVelocity =  this.speedForward * Time.deltaTime;
        float sidewaysVelocity = this.speedSideways * Time.deltaTime * -this.movementInput;

        if (rigidbody.position.z >= 4) {
            rigidbody.position = new Vector3(rigidbody.position.x, rigidbody.position.y, 4);

            if (movementInput < 0) {
                sidewaysVelocity = 0;
            }
        } else if (rigidbody.position.z <= 0) {
            rigidbody.position = new Vector3(rigidbody.position.x, rigidbody.position.y, 0);

            if (movementInput > 0) {
                sidewaysVelocity = 0;
            }
        }

        rigidbody.velocity = new Vector3(forwardVelocity, 0, sidewaysVelocity);

        
	}

    public void OnMovementInput(float movement) {
        this.movementInput = movement;
	}

    public void StopRunning() {
        this.isRunning = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
	}
}
