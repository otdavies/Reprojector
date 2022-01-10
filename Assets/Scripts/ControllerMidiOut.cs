using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMidiOut : MonoBehaviour
{
    private MidiOutSender _sender;
    // Start is called before the first frame update
    void Start()
    {
        _sender = FindObjectOfType<MidiOutSender>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _sender.SendMidiMessage(true, 0, 45, 100);
        }
    }
}
