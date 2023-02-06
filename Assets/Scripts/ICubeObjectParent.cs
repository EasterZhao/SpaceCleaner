using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICubeObjectParent 
{
    public Transform GetCubeObjectFollowTransform();
   

    public void SetCubeObject(CubeObject cubeObject);
 

    public CubeObject GetCubeObject();


    public void ClearCubeObject();
  

    public bool HasCubeObject();
    
}
