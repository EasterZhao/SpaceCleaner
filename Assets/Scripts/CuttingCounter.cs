using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{   
    [SerializeField] private CuttingObjectSO[] cuttingObjectSOArray;
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
        CubeObjectSO outputCubeObjectSO = GetOutputForInput(GetCubeObject().GetCubeObjectSO());
        // cut it and delete the original object
        GetCubeObject().DestroySelf();
        CubeObject.SpawnCubeObject(outputCubeObjectSO, this);
       }
    }

    private CubeObjectSO GetOutputForInput(CubeObjectSO inputCubeObjectSO)
    {
        foreach(CuttingObjectSO cuttingObjectSO in cuttingObjectSOArray)
        {
            if(cuttingObjectSO.input == inputCubeObjectSO)
            {
                return cuttingObjectSO.output;
            }
        }
        return null;
    }
}
