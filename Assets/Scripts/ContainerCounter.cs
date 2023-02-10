using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter 
{
    [SerializeField] private CubeObjectSO cubeObjectSO;

    public Animator animator;

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
            }

    }

}
