using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{   
    [SerializeField] private CubeObjectSO cutCubeObjectSO;
    public override void Interact(Player player)
    {

        if(!HasCubeObject())
        {
            // There is no CubeObject here
            if(player.HasCubeObject())
            {
                // Player is carrying sth
                player.GetCubeObject().SetICubeObjectParent(this);
            }
            else
            {
                // Player has nothing
            }
        }
        else
        {
            // There is a cubeObject here
            if(player.HasCubeObject())
            {
                // Player is carrying sth
            }
            else
            {
                // Player is not carrying anything
                GetCubeObject().SetICubeObjectParent(player);
            }
        }
    }

        public override void InteractAlternate(Player player)
    {
       if(HasCubeObject())
       {
        // cut it
        GetCubeObject().DestroySelf();
        Transform cubeObjectTransform = Instantiate(cutCubeObjectSO.prefab);
        cubeObjectTransform.GetComponent<CubeObject>().SetICubeObjectParent(this);
       }
    }
}
