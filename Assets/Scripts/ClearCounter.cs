using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
   
    [SerializeField] private CubeObjectSO cubeObjectSO;
    
    [SerializeField] private Transform counterTopPoint;

    private CubeObject cubeObject;

   // private Cube cubeObject;
   public void Interact()
   {
        Debug.Log("interact");
       // only one object would appear on desktop
       if(cubeObject == null)
        {
        Transform cubeObjectTransform = Instantiate(cubeObjectSO.prefab, counterTopPoint);
        cubeObjectTransform.localPosition = Vector3.zero;

        cubeObject = cubeObjectTransform.GetComponent<CubeObject>();
        }
   }
}
