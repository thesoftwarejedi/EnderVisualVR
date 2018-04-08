using AudioVisualizer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEmit : MonoBehaviour {

    private SteamVR_TrackedController _controller;

    // Use this for initialization
    void Start () {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controller.TriggerClicked += _controller_TriggerClicked;
	}

    private void _controller_TriggerClicked(object sender, ClickedEventArgs e)
    {
        GetComponentInChildren<CircleWaveform>().Blast(false);
    }

}
