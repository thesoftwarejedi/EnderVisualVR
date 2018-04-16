using AudioVisualizer;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TriggerEmit : MonoBehaviour {

    private SteamVR_TrackedController _controller;
    private SteamVR_Controller.Device _dev;
    private ParticleSystem _ps;
    private Transform _currentBall;

    public float EmmisionCount;
    public int EmmisionSpeedMax;
    public int EmmisionSpeedMin;
    public Transform Projectile;
    public int Speed;

    // Use this for initialization
    void Start () {
        _ps = GetComponentInChildren<ParticleSystem>();
        _controller = GetComponent<SteamVR_TrackedController>();
        _dev = SteamVR_Controller.Input((int)_controller.controllerIndex);
        _controller.TriggerClicked += _controller_TriggerClicked;
        _controller.TriggerUnclicked += _controller_TriggerUnclicked;
	}

    private void _controller_TriggerUnclicked(object sender, ClickedEventArgs e)
    {
        var r = _currentBall.GetComponent<Rigidbody>();
        r.AddForce(_currentBall.forward * Speed, ForceMode.VelocityChange);
        r.useGravity = true;
        _currentBall.parent = null;
        Destroy(_currentBall.gameObject, 5);
        _currentBall = null;
    }

    private void _controller_TriggerClicked(object sender, ClickedEventArgs e)
    {
        _currentBall = Instantiate(Projectile, _controller.transform, false);
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
