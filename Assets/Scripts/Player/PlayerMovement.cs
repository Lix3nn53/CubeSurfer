using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    [SerializeField] private float speedForward = 200;

    private new Rigidbody rigidbody;
    private bool isRunning = true;
    public int Line { get; private set; } // 0, 1, 2, 3, 4

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

        Line = 2;
    }

    private void FixedUpdate()
	{
        if (!isRunning) {
            return;
        }

        float forwardVelocity =  this.speedForward * Time.deltaTime;

        rigidbody.velocity = new Vector3(-forwardVelocity, 0, 0);
	}

    public void OnMovementInput(float movement) {
			if (movement == 0) {
                return;
            }
            
            if (movement > 0) {
                MoveRight();
            } else {
                MoveLeft();
            }
	}

    public void MoveRight() {
			if (Line == 4) {
                return;
            }
            Line += 1;
			transform.position = new Vector3(transform.position.x, transform.position.y, Line - 2);
	}

    public void MoveLeft() {
            if (Line == 0) {
                return;
            }
            Line -= 1;
			transform.position = new Vector3(transform.position.x, transform.position.y, Line - 2);
	}

    public void StopRunning() {
			this.isRunning = false;
            rigidbody.velocity = new Vector3(0, 0, 0);
	}
}
