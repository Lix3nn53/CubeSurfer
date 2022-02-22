using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Autofac;
using Lix.IoC;
using TMPro;

namespace Lix.CubeRunner
{
  public class PlayerMovement : MonoBehaviour
  {
    [SerializeField] private TMP_Text inputDebugText;
    [SerializeField] private float speedForward = 200;
    [SerializeField] private float speedSideways = 300;
    private new Rigidbody rigidbody;
    private bool isRunning = true;
    private float movementInput;

    private void Awake()
    {
      rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
      IInputListener inputListener = DependencyResolver.Container.Resolve<IInputListener>();

      InputAction moveAction = inputListener.GetAction(InputActionType.Move);
      moveAction.performed += OnMovementInputPerformed;
      moveAction.canceled += OnMovementInputCanceled;
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
      InputDevice device = context.control.device;
      // Debug.Log($"{device.name} performed {context.control.name}");
      // Debug.Log($"{device.description} performed {device.noisy}");
      Vector2 movementVector = context.ReadValue<Vector2>();

      float movement = movementVector.x;
      string debug = "Raw: " + movement;
      debug += " D: " + device.name;
      // TODO: find a better solution to detect different devices
      if (device.name == "Touchscreen") // if (device.noisy) is false for touchscreen
      {
        float TouchInputSensitivity = 4f;

        float temp = Mathf.Clamp(movement, -TouchInputSensitivity, TouchInputSensitivity);
        temp = Mathf.Abs(temp);
        temp = Mathf.Lerp(0f, 1f, temp / TouchInputSensitivity);
        movement = temp * Mathf.Sign(movement);
      }
      inputDebugText.text = debug;

      this.OnMovement(movement);
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
}