using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class CuttingObjectSO : ScriptableObject
{
    public CubeObjectSO input;
    public CubeObjectSO output;

    public int cuttingProgressMax;
}
