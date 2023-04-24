using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private CubeObjectSO cubeObjectSO;
    public AudioClip batteryEffect;
    public AudioClip cardboardEffect;
    private AudioSource audioSource;

    public override void Interact(Player player)
    {
        if (!HasCubeObject())
        {
            // There is no CubeObject here
            if (player.HasCubeObject())
            {
                // Player is carrying sth
                player.GetCubeObject().SetICubeObjectParent(this);
                 RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.up, out hit, 3f))
                {
                    Debug.Log("123");
                    if (hit.collider.CompareTag("battery"))
                    {
                        audioSource.PlayOneShot(batteryEffect, 0.7F);
                    }
                    else if (hit.collider.CompareTag("cardboard"))
                    {
                        audioSource.PlayOneShot(cardboardEffect, 0.7F);
                    }
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
}
