using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : IHello
{
  public Hello()
  {
    Debug.Log("Hello constructor");
  }

  public void SayHello(string name)
  {
    Debug.Log("Hello " + name);
  }
}