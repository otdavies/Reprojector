using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMidiOut : MonoBehaviour
{
    private MidiOutSender _sender;
    // Start is called before the first frame update
    private void Start()
    {
        _sender = FindObjectOfType<MidiOutSender>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Manual mapping due to time limitations
        if (Gamepad.current == null) return;

        // A
        if (Gamepad.current.aButton.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 40, 100);
        }
        if (Gamepad.current.aButton.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 40, 100);
        }

        // B
        if (Gamepad.current.bButton.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 41, 100);
        }
        if (Gamepad.current.bButton.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 41, 100);
        }

        // X 
        if (Gamepad.current.xButton.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 42, 100);
        }
        if (Gamepad.current.xButton.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 42, 100);
        }

        // Y 
        if (Gamepad.current.yButton.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 43, 100);
        }
        if (Gamepad.current.yButton.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 43, 100);
        }

        // Left 
        if (Gamepad.current.dpad.left.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 44, 100);
        }
        if (Gamepad.current.dpad.left.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 44, 100);
        }

        // Right 
        if (Gamepad.current.dpad.right.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 45, 100);
        }
        if (Gamepad.current.dpad.right.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 45, 100);
        }

        // Up 
        if (Gamepad.current.dpad.up.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 46, 100);
        }
        if (Gamepad.current.dpad.up.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 46, 100);
        }

        // Down 
        if (Gamepad.current.dpad.down.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 47, 100);
        }
        if (Gamepad.current.dpad.down.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 47, 100);
        }

        // l bumper
        if (Gamepad.current.leftShoulder.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 48, 100);
        }
        if (Gamepad.current.leftShoulder.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 48, 100);
        }

        // r bumper
        if (Gamepad.current.rightShoulder.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 49, 100);
        }
        if (Gamepad.current.rightShoulder.wasReleasedThisFrame)
        {
            _sender.SendMidiMessage(false, 0, 49, 100);
        }
    }
}
