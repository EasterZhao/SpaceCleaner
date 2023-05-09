using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Counter
{
    public class TrashCounter : BaseCounter
    {
        public AudioClip soundEffect;
        private AudioSource audioSource;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }


        public override void Interact(Player player)
        {
            if (player.HasCubeObject())
            {
                player.GetCubeObject().DestroySelf();
                audioSource.PlayOneShot(soundEffect, 0.7F);

            }
        }

    }

}