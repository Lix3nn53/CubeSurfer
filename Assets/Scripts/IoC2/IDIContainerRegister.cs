using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDIContainerRegister
{
  public void RegisterDependencies(DIContainerBuilder builder);
}
