using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZeroCoords : MonoBehaviour
{
    void Update()
    {
        // Calculate the position of the object in world space
        Vector3 worldPos = transform.position;
        
        // Set the position of the object to (0, 0, 0) in world space
        worldPos = Vector3.zero;
        
        // Transform the object back to its local space
        transform.position = worldPos;
    }
}