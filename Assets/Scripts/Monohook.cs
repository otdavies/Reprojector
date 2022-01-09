using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Monohook : MonoBehaviour
{
    private Camera _camera;
    private VideoQuad _renderQuad;
    private Vector2 _axis = Vector2.zero;
    private Vector2 _axis_lerped = Vector2.zero;
    private void Awake()
    {
        _camera = GameObject.FindObjectOfType<Camera>();
        _renderQuad = new VideoQuad(this, _camera, 30, 30);
        Application.targetFrameRate = 60;
    }

    private void OnKeystoneChange(InputValue input)
    {
        _axis = input.Get<Vector2>();
        Debug.Log(_axis);
    }

    private void Update()
    {
        _axis_lerped = Vector2.Lerp(_axis_lerped, _axis, Time.deltaTime);
        _renderQuad.PanTilt(_axis_lerped.x * 30, _axis_lerped.y * 30);
        // _axis = Vector2.zero;
    }
}
