using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    [SerializeField] private CubeObjectSO cubeObjectSO;

    private ICubeObjectParent  cubeObjectParent;

    public CubeObjectSO GetCubeObjectSO()
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

    public void DestroySelf()
    {
        cubeObjectParent.ClearCubeObject();
        Destroy(gameObject);
    }

    public static CubeObject SpawnCubeObject(CubeObjectSO cubeObjectSO, ICubeObjectParent cubeObjectParent)
    {
        Transform cubeObjectTransform = Instantiate(cubeObjectSO.prefab);
        CubeObject cubeObject = cubeObjectTransform.GetComponent<CubeObject>();
        cubeObject.SetICubeObjectParent(cubeObjectParent);
        return cubeObject;
    }
}
