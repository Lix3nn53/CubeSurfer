using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private Renderer _renderer = null;
    private MaterialPropertyBlock materialPropertyBlock = null;

    private void Awake() {
        _renderer = GetComponent<Renderer>();
        materialPropertyBlock = new MaterialPropertyBlock();

        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        materialPropertyBlock.SetColor("_BaseColor", randomColor);
        _renderer.SetPropertyBlock(materialPropertyBlock);
    }
}
