using System.Collections;
using System.Collections.Generic;
using Klak.Ndi;
using UnityEngine;
using UnityEngine.InputSystem;

public class NDIVideoProjector : MonoBehaviour
{
    [SerializeField] NdiResources _resources = null;
    [SerializeField] [Range(0, 90)] float _maxTilt;
    [SerializeField] [Range(0, 90)] float _maxPan;
    [SerializeField] [Range(0, 5)] float _maxZoom;
    [SerializeField] [Range(0, 10)] float _sensitivity;
    private Camera _camera;
    private VideoQuad _renderQuad;
    private Vector2 _axis = Vector2.zero;
    private Vector2 _axis_lerped = Vector2.zero;
    private Vector3 _axis_accumulated = Vector3.zero;

    private float _zoom = 0;
    private float _zoom_lerped = 0;
    private float _zoom_accumulated = 0;
    private void Awake()
    {
        _camera = GameObject.FindObjectOfType<Camera>();
        _renderQuad = new VideoQuad(this, _camera, _maxTilt, _maxPan, _maxZoom);
        Application.targetFrameRate = 60;
        _renderQuad.SetupNDI(_resources);
    }

    private void Start()
    {
        _renderQuad.SetFOV(30);
    }

    private void OnKeystoneChange(InputValue input)
    {
        _axis = input.Get<Vector2>();
    }

    private void OnZoom(InputValue input)
    {
        _zoom = input.Get<float>();
    }

    private void OnReset()
    {
        _axis = Vector2.zero;
        _axis_lerped = Vector2.zero;
        _axis_accumulated = Vector3.zero;
        _zoom_lerped = 0;
        _zoom_accumulated = 0;
    }

    private void Update()
    {
        _axis_lerped = Vector2.Lerp(_axis_lerped, _axis, Time.deltaTime * 3);
        _zoom_lerped = Mathf.Lerp(_zoom_lerped, _zoom, Time.deltaTime * 3);
        _zoom_accumulated = Mathf.Clamp(_zoom_accumulated + _zoom_lerped * Time.deltaTime * _sensitivity, 0, _maxZoom);
        _axis_accumulated = new Vector3(Mathf.Clamp(_axis_accumulated.x + _axis_lerped.x * Time.deltaTime * _sensitivity, -1, 1),
        Mathf.Clamp(_axis_accumulated.y + _axis_lerped.y * Time.deltaTime * _sensitivity, -1, 1),
        _zoom_accumulated);
        _renderQuad.PanTiltZoom(_axis_accumulated.x * _maxTilt, _axis_accumulated.y * _maxPan, _axis_accumulated.z * _maxZoom);

    }
}
