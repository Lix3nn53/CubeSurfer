using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeting : IGreeting
{
  private string name = "Lix3nn";
  public void Greet()
  {
    Debug.Log("Hello " + name + "!");
  }
}
