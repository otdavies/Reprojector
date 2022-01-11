// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""d92a292c-95c7-4418-a55d-103a6aeac1bd"",
            ""actions"": [
                {
                    ""name"": ""KeystoneChange"",
                    ""type"": ""Value"",
                    ""id"": ""9f9b967b-03cf-49e4-9896-fea42b6439f5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""5a02e413-2a11-4e35-b92b-749e00de0834"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""f06e3ca7-d612-452a-ba14-ec59e8c02425"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CorrectDepthToggle"",
                    ""type"": ""Button"",
                    ""id"": ""951f9602-2791-4393-b400-923594e30342"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleGrid"",
                    ""type"": ""Button"",
                    ""id"": ""300ab3c5-8226-4be6-a5a0-97d3a01052ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a2b2e985-23a1-404d-805f-b81aa4845941"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4bb4d745-c60c-4157-85cd-46e8eb853356"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5d2f23e2-5ffd-45da-8e94-7b6f41178432"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ccd898a5-1588-4f34-b288-496e48f0e40e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a20ae73f-8fd7-4e57-a03e-fc2d14d3054c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""XboxLeftStick"",
                    ""id"": ""01b731f1-0f18-4792-a3d5-5f091ab9837d"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fdd556ab-9b19-41ef-b0a6-b05be081ec88"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5a9f16f1-8e2c-4467-ae37-bd5a160b8f6b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""835d2991-7f44-48f3-b59e-380b7c00de26"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5c2fb72f-9062-4196-b902-522ce628d8e8"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""XboxDPad"",
                    ""id"": ""e41466ae-c7b8-4e19-b8a2-b64fbb7c9ac8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""56085e3b-bbf6-4d7c-a87e-a650bd085b60"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a2422baa-5dbe-4bf2-afcf-123ef97896a2"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7caaa50c-3421-41be-872f-2d4f26bae04c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f7e01fd0-aa02-424c-ad33-e5dc8f1ae391"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeystoneChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""QE"",
                    ""id"": ""b089d567-4f9a-4758-bb7f-9352ac4b4140"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""58349c40-b3bb-4636-9557-0669af99dc3e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7c053fe9-52f2-4948-807c-cd15333be70a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""XboxTriggers"",
                    ""id"": ""1e3aba7e-e290-4d72-915f-121710b7b3a9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""24235f9c-3509-481a-8e0b-c8003720d025"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""75eee04a-7333-494e-9069-29623ea3e4cb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""52a18bf1-c864-41e9-ab88-5bc8b23478b7"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d2a645a-caae-464b-bbcb-f17ce727054d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b13ae47-1072-424d-a63a-8a77f8911c61"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CorrectDepthToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca096a36-d9ba-4383-970e-9c9501ff666c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControls"",
                    ""action"": ""CorrectDepthToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf139502-ffb4-44ca-9d3e-bb5f84c2e5b0"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleGrid"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b31e56af-2f93-4eea-9813-76006044a6a8"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControls"",
                    ""action"": ""ToggleGrid"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardControls"",
            ""bindingGroup"": ""KeyboardControls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_KeystoneChange = m_Movement.FindAction("KeystoneChange", throwIfNotFound: true);
        m_Movement_Zoom = m_Movement.FindAction("Zoom", throwIfNotFound: true);
        m_Movement_Reset = m_Movement.FindAction("Reset", throwIfNotFound: true);
        m_Movement_CorrectDepthToggle = m_Movement.FindAction("CorrectDepthToggle", throwIfNotFound: true);
        m_Movement_ToggleGrid = m_Movement.FindAction("ToggleGrid", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_KeystoneChange;
    private readonly InputAction m_Movement_Zoom;
    private readonly InputAction m_Movement_Reset;
    private readonly InputAction m_Movement_CorrectDepthToggle;
    private readonly InputAction m_Movement_ToggleGrid;
    public struct MovementActions
    {
        private @InputActions m_Wrapper;
        public MovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @KeystoneChange => m_Wrapper.m_Movement_KeystoneChange;
        public InputAction @Zoom => m_Wrapper.m_Movement_Zoom;
        public InputAction @Reset => m_Wrapper.m_Movement_Reset;
        public InputAction @CorrectDepthToggle => m_Wrapper.m_Movement_CorrectDepthToggle;
        public InputAction @ToggleGrid => m_Wrapper.m_Movement_ToggleGrid;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @KeystoneChange.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnKeystoneChange;
                @KeystoneChange.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnKeystoneChange;
                @KeystoneChange.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnKeystoneChange;
                @Zoom.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnZoom;
                @Reset.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnReset;
                @CorrectDepthToggle.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCorrectDepthToggle;
                @CorrectDepthToggle.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCorrectDepthToggle;
                @CorrectDepthToggle.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCorrectDepthToggle;
                @ToggleGrid.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnToggleGrid;
                @ToggleGrid.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnToggleGrid;
                @ToggleGrid.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnToggleGrid;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @KeystoneChange.started += instance.OnKeystoneChange;
                @KeystoneChange.performed += instance.OnKeystoneChange;
                @KeystoneChange.canceled += instance.OnKeystoneChange;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @CorrectDepthToggle.started += instance.OnCorrectDepthToggle;
                @CorrectDepthToggle.performed += instance.OnCorrectDepthToggle;
                @CorrectDepthToggle.canceled += instance.OnCorrectDepthToggle;
                @ToggleGrid.started += instance.OnToggleGrid;
                @ToggleGrid.performed += instance.OnToggleGrid;
                @ToggleGrid.canceled += instance.OnToggleGrid;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_KeyboardControlsSchemeIndex = -1;
    public InputControlScheme KeyboardControlsScheme
    {
        get
        {
            if (m_KeyboardControlsSchemeIndex == -1) m_KeyboardControlsSchemeIndex = asset.FindControlSchemeIndex("KeyboardControls");
            return asset.controlSchemes[m_KeyboardControlsSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnKeystoneChange(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnCorrectDepthToggle(InputAction.CallbackContext context);
        void OnToggleGrid(InputAction.CallbackContext context);
    }
}
