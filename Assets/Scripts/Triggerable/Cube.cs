using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autofac;

namespace Lix.CubeRunner
{
  public class Cube : Triggerable
  {
    private PlayerCollider playerCollider;

    private void Start()
    {
      playerCollider = DependencyResolver.Container.Resolve<PlayerCollider>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      playerCollider.OnCube(this.gameObject);
      Destroy(this); // Removes this script instance from the game object
    }
  }
}