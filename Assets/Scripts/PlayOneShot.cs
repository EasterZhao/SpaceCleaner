using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShot : MonoBehaviour
{
    public AudioClip soundEffect;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Get an instance of the ContainerCounter class
        ContainerCounter containerCounter = FindObjectOfType<ContainerCounter>();

        // Check if the instance was found before subscribing to the event
 
            containerCounter.OnPickUpTrash += ContainerCounter_OnPickUpTrash;
        
    }

    private void ContainerCounter_OnPickUpTrash(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(soundEffect, 0.7F);
    }
}