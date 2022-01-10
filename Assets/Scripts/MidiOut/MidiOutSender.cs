using System.Collections.Generic;
using RtMidi.LowLevel;
using UnityEngine;

sealed class MidiOutSender : MonoBehaviour
{
    #region Private members

    MidiProbe _probe;
    List<MidiOutPort> _ports = new List<MidiOutPort>();

    // Does the port seem real or not?
    // This is mainly used on Linux (ALSA) to filter automatically generated
    // virtual ports.
    bool IsRealPort(string name)
    {
        return !name.Contains("Through") && !name.Contains("RtMidi") && !name.Contains("Microsoft");
    }

    // Scan and open all the available output ports.
    void ScanPorts()
    {
        for (var i = 0; i < _probe.PortCount; i++)
        {
            var name = _probe.GetPortName(i);
            Debug.Log("MIDI-out port found: " + name);
            _ports.Add(IsRealPort(name) ? new MidiOutPort(i) : null);
        }
    }

    // Close and release all the opened ports.
    void DisposePorts()
    {
        foreach (var p in _ports) p?.Dispose();
        _ports.Clear();
    }

    #endregion

    #region MonoBehaviour implementation

    System.Collections.IEnumerator Start()
    {
        _probe = new MidiProbe(MidiProbe.Mode.Out);

        yield return new WaitForSeconds(0.1f);

        // Send an all-sound-off message.
        foreach (var port in _ports) port?.SendAllOff(0);

        // for (var i = 0; true; i++)
        // {
        //     var note = 40 + (i % 30);

        //     Debug.Log("MIDI Out: Note On " + note);
        //     foreach (var port in _ports) port?.SendNoteOn(0, note, 100);

        //     yield return new WaitForSeconds(0.1f);

        //     Debug.Log("MIDI Out: Note Off " + note);
        //     foreach (var port in _ports) port?.SendNoteOff(0, note);

        //     yield return new WaitForSeconds(0.1f);
        // }
    }

    public void SendMidiMessage(bool noteOn, int channel, int note, int velocity)
    {
        if (noteOn) foreach (var port in _ports) port?.SendNoteOn(channel, note, velocity);
        else foreach (var port in _ports) port?.SendNoteOff(channel, note);
    }

    void Update()
    {
        // Rescan when the number of ports changed.
        if (_ports.Count != _probe.PortCount)
        {
            DisposePorts();
            ScanPorts();
        }
    }

    void OnDestroy()
    {
        _probe?.Dispose();
        DisposePorts();
    }

    #endregion
}
