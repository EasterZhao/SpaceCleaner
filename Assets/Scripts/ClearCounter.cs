using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
   
    [SerializeField] private Transform cubePrefab;
    
    [SerializeField] private Transform counterTopPoint;
   public void Interact()
   {
        Debug.Log("interact");
        Transform cubeTransform = Instantiate(cubePrefab, counterTopPoint);
        cubeTransform.localPosition = Vector3.zero;
   }
}
