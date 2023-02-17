using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform myObject = GetComponent<Transform>();
        myObject.Rotate(-30f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
