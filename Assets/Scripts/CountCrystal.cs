using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CountCrystal : MonoBehaviour
{
    public int crystalCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
             crystalCount++;
        }
        if (other.tag == "CrystalA")
        {
             crystalCount++;
        }
        if (other.tag == "CrystalB")
        {
             crystalCount++;
        }
        if (other.tag == "CrystalC")
        {
             crystalCount++;
        }
           if (crystalCount == 4)
            {
                SceneManager.LoadScene(3, LoadSceneMode.Single);
            }
    }
}
