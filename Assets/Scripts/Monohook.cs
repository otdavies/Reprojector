using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monohook : MonoBehaviour
{
    private Camera _camera;
    private RenderQuad _renderQuad;
    private void Start()
    {
        _camera = GameObject.FindObjectOfType<Camera>();
        _renderQuad = new RenderQuad(this, _camera);
        Application.targetFrameRate = 60;
    }

    private void Update()
    {

    }
}
