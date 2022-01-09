using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Monohook : MonoBehaviour
{
    private Camera _camera;
    private VideoQuad _renderQuad;
    private void Awake()
    {
        _camera = GameObject.FindObjectOfType<Camera>();
        _renderQuad = new VideoQuad(this, _camera, 30, 30);
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        _renderQuad.PanTilt(horizontal * 30, vertical * 30);
    }
}
