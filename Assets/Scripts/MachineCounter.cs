using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MachineCounter : BaseCounter,IHasProgress
{   
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    private enum State
    {
        Idle,
        Processing,
        Processed,
       // Broken,
        
    }
   [SerializeField] private UnprocessedRecipeSO[] unprocessedRecipeSOArray;

    private float processTimer;
    private UnprocessedRecipeSO unprocessedRecipeSO;
    private State state;

    private void Start() 
    {
        state = State.Idle;
    }
    private void Update()
    {        
        if(HasCubeObject())
        {
        switch (state)
        {
            case State.Idle:
                break;
            case State.Processing:            
            processTimer += Time.deltaTime;
             OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = processTimer / unprocessedRecipeSO.fryingTimeMax
                    });
                
            
           
            if(processTimer  > unprocessedRecipeSO.fryingTimeMax )
            {
                processTimer = 0f;
                GetCubeObject().DestroySelf();
                CubeObject.SpawnCubeObject(unprocessedRecipeSO.output, this);
                state = State.Processed;
                 OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = 0f
                    });
                
            }
            
                break;
            case State.Processed:
                break;
            //case State.Broken:
                //break;

        }

           

        }
   }
    public override void Interact(Player player)
    {

        if (!HasCubeObject())
        {
            // There is no CubeObject here
            if (player.HasCubeObject())
            {
                // Player is carrying sth
                if (HasCubeObjectWithInput(player.GetCubeObject().GetCubeObjectSO()))
                {
                    player.GetCubeObject().SetICubeObjectParent(this);
                    unprocessedRecipeSO = GetUnprocessedRecipeSOWithInput(GetCubeObject().GetCubeObjectSO());
                    state = State.Processing;
                    processTimer = 0f;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = processTimer / unprocessedRecipeSO.fryingTimeMax
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
