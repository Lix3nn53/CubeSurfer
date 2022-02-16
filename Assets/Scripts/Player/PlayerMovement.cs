using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Singleton<PlayerMovement>
{
  [SerializeField] private float speedForward = 200;
  [SerializeField] private float speedSideways = 300;
  private new Rigidbody rigidbody;
  private bool isRunning = true;

  private float movementInput;

  protected override void Awake()
  {
    base.Awake();
    rigidbody = GetComponent<Rigidbody>();
  }

  private void Start()
  {
    InputListener.Instance.ActionMove.performed += OnMovementInputPerformed;
    InputListener.Instance.ActionMove.canceled += OnMovementInputCanceled;
  }

  private void FixedUpdate()
  {
    if (!isRunning)
    {
      return;
    }

    float forwardVelocity = this.speedForward * Time.deltaTime;
    float sidewaysVelocity = this.speedSideways * Time.deltaTime * -this.movementInput;

    if (rigidbody.position.z >= 4)
    {
      rigidbody.position = new Vector3(rigidbody.position.x, rigidbody.position.y, 4);

      if (movementInput < 0)
      {
        sidewaysVelocity = 0;
      }
    }
    else if (rigidbody.position.z <= 0)
    {
      rigidbody.position = new Vector3(rigidbody.position.x, rigidbody.position.y, 0);

      if (movementInput > 0)
      {
        sidewaysVelocity = 0;
      }
    }

    rigidbody.velocity = new Vector3(forwardVelocity, 0, sidewaysVelocity);


  }

  public void OnMovement(float movement)
  {
    this.movementInput = movement;
  }

  public void StopRunning()
  {
    this.isRunning = false;
    rigidbody.velocity = new Vector3(0, 0, 0);
  }

  private void OnMovementInputPerformed(InputAction.CallbackContext context)
  {
    Vector2 movement = context.ReadValue<Vector2>();
    this.OnMovement(movement.x);
  }

  private void OnMovementInputCanceled(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      Vector2 movement = context.ReadValue<Vector2>();
      this.OnMovement(movement.x);
    }
    else if (context.canceled)
    {
      this.OnMovement(0f);
    }
  }
}
