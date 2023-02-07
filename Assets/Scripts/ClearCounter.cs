using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private CubeObjectSO cubeObjectSO;

    // private Cube cubeObject;

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
        }
        else
        {
            // There is a cubeObject here
        }

    }

}
