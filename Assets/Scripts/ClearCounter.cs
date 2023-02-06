using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, ICubeObjectParent 
{

    [SerializeField] private CubeObjectSO cubeObjectSO;

    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private CubeObject cubeObject;

    // private Cube cubeObject;
    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (cubeObject != null)
            {
                cubeObject.SetICubeObjectParent(secondClearCounter);
            }
        }
    }

    public void Interact(Player player)
    {
        // only one object would appear on desktop
        if (cubeObject == null)
        {
            Transform cubeObjectTransform = Instantiate(cubeObjectSO.prefab, counterTopPoint);
            cubeObjectTransform.GetComponent<CubeObject>().SetICubeObjectParent(this);

        }
        else
        {
          // give the object to the player
            Debug.Log(cubeObject.GetCubeObjectParent());
           cubeObject.SetICubeObjectParent(player);
        }

    }
    public Transform GetCubeObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetCubeObject(CubeObject cubeObject)
    {
        this.cubeObject = cubeObject;
    }

    public CubeObject GetCubeObject()
    {
        return cubeObject;
    }

    public void ClearCubeObject()
    {
          cubeObject = null;
    }

    public bool HasCubeObject()
    {
     return cubeObject != null;
    }

}
