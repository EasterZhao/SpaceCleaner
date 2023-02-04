using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    [SerializeField] private CubeObjectSO cubeObjectSO;

    public CubeObjectSO GetcubeObjectSO()
    {
        return cubeObjectSO;
    }
}
