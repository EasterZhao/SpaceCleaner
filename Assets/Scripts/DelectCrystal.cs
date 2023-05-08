using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelectCrystal : MonoBehaviour
{
        private void OnTriggerEnter(Collider other) {
        if(other.tag =="Crystal")
        {
          //Debug.Log("this is Crystal");
          Destroy(gameObject);
          //gameObject.transform.localPosition= new Vector3(99999, 99999 ,999999);
        }
    }
}
