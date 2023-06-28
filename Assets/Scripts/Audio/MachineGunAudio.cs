using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunAudio : MonoBehaviour
{
    [SerializeField] private MachineGun _machineGun;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _burstDuration;

    private float _stopAudioTime;

    // Start is called before the first frame update
    private bool _isShooting = false;

    void Start()
    {
        // _machineGun.OnStartShooting += Play;
        // _machineGun.OnStopShooting += Stop;
        _machineGun.OnShoot += _audioSource.Play;
        enabled = false;
    }

    private void Stop()
    {
        _stopAudioTime = Time.time + _burstDuration;
        _isShooting = false;
    }

    private void Play()
    {
        enabled = true;
        _audioSource.Play();
        _isShooting = true;
    }

    private void Update()
    {
        if (_isShooting) return;
        if (Time.time >= _stopAudioTime)
        {
            _audioSource.Stop();
            enabled = false;
        }
    }
}