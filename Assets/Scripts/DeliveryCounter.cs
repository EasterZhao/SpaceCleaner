using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasCubeObject())
        {
            
           // if (gameObject.CompareTag("Crystal"))
            //{
               player.GetCubeObject().DestroySelf();
            //}          
        }
    }
}
