using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterAniamtion : MonoBehaviour
{
    [SerializeField] private Counter.CuttingCounter cuttingCounter;

    public Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }
    
    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, EventArgs e)
    {
        animator.SetBool("IsCutting", true);
        StartCoroutine(StopAnimatingAfterSecond());
    }

        IEnumerator StopAnimatingAfterSecond()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("IsCutting", false);
    }
}
