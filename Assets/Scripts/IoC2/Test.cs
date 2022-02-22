using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.CubeRunner;

public class Test : MonoBehaviour
{
  [SerializeField] private InputListener inputListener;


  // Start is called before the first frame update
  void Awake()
  {
    var services = new DIServiceCollection();

    services.RegisterSingleton<InputListener>(inputListener);

    var container = services.GenerateContainer();

    var service = container.GetService<IInputListener>();


  }

  // Update is called once per frame
  void Update()
  {

  }
}
