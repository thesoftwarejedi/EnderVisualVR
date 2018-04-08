using AudioVisualizer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEmit : MonoBehaviour {

    private SteamVR_TrackedController _controller;
    private ParticleSystem _ps;

    // Use this for initialization
    void Start () {
        _ps = GetComponentInChildren<ParticleSystem>();
        _controller = GetComponent<SteamVR_TrackedController>();
        _controller.TriggerClicked += _controller_TriggerClicked;
	}

    private void _controller_TriggerClicked(object sender, ClickedEventArgs e)
    {
        var em = _ps.emission;
        em.rateOverDistanceMultiplier = e.padX;
    }

}
