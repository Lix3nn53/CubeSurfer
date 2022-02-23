using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DIContainerRegisterMono : MonoBehaviour, IDIContainerRegister
{
  public abstract void RegisterDependencies(DIContainerBuilder builder);
}
