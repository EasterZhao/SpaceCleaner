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
        // only one object would appear on desktop
            Transform cubeObjectTransform = Instantiate(cubeObjectSO.prefab);
            cubeObjectTransform.GetComponent<CubeObject>().SetICubeObjectParent(player);

            animator.SetBool("OpenClose", true);


    }

}
