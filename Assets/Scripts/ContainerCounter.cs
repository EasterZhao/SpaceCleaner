using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Counter
{

    public class ContainerCounter : BaseCounter
    {
        [SerializeField] private CubeObjectSO cubeObjectSO;

        public Animator animator;
        public AudioClip soundEffect;
        private AudioSource audioSource;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }


        public override void Interact(Player player)
        {
            if (!player.HasCubeObject())
            {
                // only one object would appear on desktop
                CubeObject.SpawnCubeObject(cubeObjectSO, player);
                animator.SetBool("OpenClose", true);
                audioSource.PlayOneShot(soundEffect, 0.7F);
            }
        }
    }

}