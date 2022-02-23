using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.CubeRunner;

public class ContainerCore : DIContainerRegisterMono
{
  [SerializeField] private InputListener inputListener;

  public override void RegisterDependencies(DIContainerBuilder builder)
  {
    builder.RegisterSingleton<IInputListener>(inputListener);
  }
}
