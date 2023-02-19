using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class UnprocessedRecipeSO : ScriptableObject
{
    public CubeObjectSO input;
    public CubeObjectSO output;
    public float fryingTimeMax;
}
