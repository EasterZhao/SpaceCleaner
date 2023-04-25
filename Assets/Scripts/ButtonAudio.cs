using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource mySource;
    public AudioClip hoverSound;
    
    public void HoverSound()
    {
        mySource.PlayOneShot(hoverSound);
    }
}
