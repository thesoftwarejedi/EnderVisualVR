using AudioVisualizer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEmit : MonoBehaviour {

    private SteamVR_TrackedController _controller;
    private SteamVR_Controller.Device _dev;
    private ParticleSystem _ps;

    public float EmmisionCount;
    public int EmmisionSpeedMax;
    public int EmmisionSpeedMin;

    // Use this for initialization
    void Start () {
        _ps = GetComponentInChildren<ParticleSystem>();
        _controller = GetComponent<SteamVR_TrackedController>();
        _dev = SteamVR_Controller.Input((int)_controller.controllerIndex);
	}

    private void Update()
    {
        var t = _dev.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        var em = _ps.emission;
        em.rateOverTime = new ParticleSystem.MinMaxCurve(EmmisionCount * t.x);
        var m = _ps.main;
        m.startSpeed = new ParticleSystem.MinMaxCurve(EmmisionSpeedMin * t.x, EmmisionSpeedMax * t.x);
    }

}
