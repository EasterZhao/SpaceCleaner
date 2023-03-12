using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ContainerCounter : BaseCounter 
{
    [SerializeField] private CubeObjectSO cubeObjectSO;

    public Animator animator;

    public event EventHandler OnPickUpTrash;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }


    public override void Interact(Player player)
    {
        if(!player.HasCubeObject())
            {
            // only one object would appear on desktop
             CubeObject.SpawnCubeObject(cubeObjectSO, player);    
            animator.SetBool("OpenClose", true);
            OnPickUpTrash?.Invoke(this,EventArgs.Empty);
            
            }

    }

}
