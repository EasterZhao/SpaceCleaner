using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronomyCounter : BaseCounter
{
    private bool isWatching = false;
    public GameObject myCamera;
    public GameObject mySecondCamera;
    public GameObject panel;
    public AudioClip soundEffect;
    private AudioSource audioSource;
        private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact(Player player)
    {
        if (!player.HasCubeObject() && !isWatching) 
        {
            // Get the Transform component of the myCamera object and rotate it
            myCamera.SetActive(false);
            mySecondCamera.SetActive(true);
            isWatching = true;
            panel.SetActive(false);
            audioSource.PlayOneShot(soundEffect, 0.7F);

        }
        else if (!player.HasCubeObject() && isWatching) 
        {
            // Get the Transform component of the myCamera object and rotate it back to its original position
            myCamera.SetActive(true);
            mySecondCamera.SetActive(false);
            isWatching = false;
            panel.SetActive(true);
            
        }
    }
}

