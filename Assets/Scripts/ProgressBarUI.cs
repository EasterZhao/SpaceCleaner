using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private CuttingCounter cuttingCounter;


    // Start is called before the first frame update
    void Start()
    {
        cuttingCounter.OnProgressChanged += CuttingCounter_OnprogressChanged;
        barImage.fillAmount = 0f;
        gameObject.SetActive(false);

    }

    private void CuttingCounter_OnprogressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if(e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            gameObject.SetActive(false);
        }
        else
        {gameObject.SetActive(true);
        }
        
    }
}

