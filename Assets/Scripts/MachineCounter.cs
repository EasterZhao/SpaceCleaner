using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MachineCounter : BaseCounter
{
   [SerializeField] private UnprocessedRecipeSO[] unprocessedRecipeSOArray;
    public override void Interact(Player player)
    {

        if (!HasCubeObject())
        {
            // There is no CubeObject here
            if (player.HasCubeObject())
            {
                // Player is carrying sth
                if (HasCubeObjectWithInput(player.GetCubeObject().GetCubeObjectSO()))
                {player.GetCubeObject().SetICubeObjectParent(this);
             
                }

            }
            else
            {
                // Player has nothing
            }
        }
        else
        {
            // There is a cubeObject here
            if (player.HasCubeObject())
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
      private bool HasCubeObjectWithInput(CubeObjectSO inputCubeObjectSO)
    {
        UnprocessedRecipeSO unprocessedRecipeSO = GetUnprocessedRecipeSOWithInput(inputCubeObjectSO);
        return unprocessedRecipeSO != null;
    }

    private CubeObjectSO GetOutputForInput(CubeObjectSO inputCubeObjectSO)
    {
        UnprocessedRecipeSO unprocessedRecipeSO = GetUnprocessedRecipeSOWithInput(inputCubeObjectSO);
        if (unprocessedRecipeSO != null)
        {
            return unprocessedRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private UnprocessedRecipeSO GetUnprocessedRecipeSOWithInput(CubeObjectSO inputCubeObjectSO)
    {
        foreach (UnprocessedRecipeSO unprocessedRecipeSO in unprocessedRecipeSOArray)
        {
            if (unprocessedRecipeSO.input == inputCubeObjectSO)
            {
                return unprocessedRecipeSO;
            }
        }
        return null;
    }
    
}
