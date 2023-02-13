using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingObjectSO[] cuttingObjectSOArray;
  public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    private int cuttingProgress;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }

public event  EventHandler OnCut;

  
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
                    cuttingProgress = 0;
                    CuttingObjectSO cuttingObjectSO = GetCuttingObjectSOWithInput(GetCubeObject().GetCubeObjectSO());
                    
                    
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress / cuttingObjectSO.cuttingProgressMax

                    });

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

    public override void InteractAlternate(Player player)
    {
        if (HasCubeObject() && HasCubeObjectWithInput(GetCubeObject().GetCubeObjectSO()))
        {

            cuttingProgress++; 
            OnCut?.Invoke(this, EventArgs.Empty);
            CuttingObjectSO cuttingObjectSO = GetCuttingObjectSOWithInput(GetCubeObject().GetCubeObjectSO());
            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            {
                progressNormalized = (float)cuttingProgress / cuttingObjectSO.cuttingProgressMax

            });

            // cut it and delete the original object
            if (cuttingProgress >= cuttingObjectSO.cuttingProgressMax)
            {
                CubeObjectSO outputCubeObjectSO = GetOutputForInput(GetCubeObject().GetCubeObjectSO());
                GetCubeObject().DestroySelf();
                CubeObject.SpawnCubeObject(outputCubeObjectSO, this);
            }
        }
    }

    private bool HasCubeObjectWithInput(CubeObjectSO inputCubeObjectSO)
    {
        CuttingObjectSO cuttingObjectSO = GetCuttingObjectSOWithInput(inputCubeObjectSO);
        return cuttingObjectSO != null;
    }

    private CubeObjectSO GetOutputForInput(CubeObjectSO inputCubeObjectSO)
    {
        CuttingObjectSO cuttingObjectSO = GetCuttingObjectSOWithInput(inputCubeObjectSO);
        if (cuttingObjectSO != null)
        {
            return cuttingObjectSO.output;
        }
        else
        {
            return null;
        }
    }

    private CuttingObjectSO GetCuttingObjectSOWithInput(CubeObjectSO inputCubeObjectSO)
    {
        foreach (CuttingObjectSO cuttingObjectSO in cuttingObjectSOArray)
        {
            if (cuttingObjectSO.input == inputCubeObjectSO)
            {
                return cuttingObjectSO;
            }
        }
        return null;
    }
}
