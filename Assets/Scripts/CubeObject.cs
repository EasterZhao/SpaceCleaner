using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    [SerializeField] private CubeObjectSO cubeObjectSO;

    private ICubeObjectParent  cubeObjectParent;

    public CubeObjectSO GetcubeObjectSO()
    {
        return cubeObjectSO;
    }

    public void SetICubeObjectParent (ICubeObjectParent  cubeObjectParent)
    {
        if(this.cubeObjectParent != null)
        {
            this.cubeObjectParent.ClearCubeObject();
        }
        this.cubeObjectParent = cubeObjectParent;
        cubeObjectParent.SetCubeObject(this);

        transform.parent = cubeObjectParent.GetCubeObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ICubeObjectParent  GetCubeObjectParent()
    {
        return cubeObjectParent;
    }
}
