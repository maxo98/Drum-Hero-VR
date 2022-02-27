using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    [SerializeField] 
    private bool playOnButton = false;
    
    private readonly Random _rand = new Random();
    private void Update()
    {
        if (playOnButton)
            CheckButtonPress();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("drumstickhead")) return;
        
        source.volume = other.gameObject.GetComponent<TrackStickSpeed>().speed;
        ActivateSound();
    }

    private void ActivateSound()
    {
        
        source.pitch = (float) _rand.Next(9, 11) / 10;
        source.Play();
    }

    private void CheckButtonPress()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X))
            ActivateSound();
    }
}
