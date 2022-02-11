using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBController : MonoBehaviour
{
    [SerializeField] private Color mainColor = Color.black;

    private Renderer renderer = null;
    private MaterialPropertyBlock materialPropertyBlock = null;

    private void Awake() {
        renderer = GetComponent<Renderer>();
        materialPropertyBlock = new MaterialPropertyBlock();

        materialPropertyBlock.SetColor("_BaseColor", mainColor);
        renderer.SetPropertyBlock(materialPropertyBlock);
    }
}
