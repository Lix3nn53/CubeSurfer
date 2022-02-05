using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedForward;
    [SerializeField] private float speedSideways;

    // PLAYER INPUTS
    private float movementInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sideWaysVelocity = movementInput * speedSideways * Time.deltaTime;
        float forwardVelocity =  speedForward * Time.deltaTime;

        this.transform.Translate(sideWaysVelocity, 0, forwardVelocity);
    }

    public void OnMovement(float movement) {
			this.movementInput = movement;
	}
}
