using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronomyCounter : BaseCounter
{
    private bool isWatching = false;
    public GameObject myCamera;

    public override void Interact(Player player)
    {
        if (!player.HasCubeObject() && !isWatching) 
        {
            // Get the Transform component of the myCamera object and rotate it
            myCamera.transform.Rotate(-30f, 0f, 0f);
            isWatching = true;
        }
        else if (!player.HasCubeObject() && isWatching) 
        {
            // Get the Transform component of the myCamera object and rotate it back to its original position
            myCamera.transform.Rotate(30f, 0f, 0f);
            isWatching = false;
        }
    }
}

