using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField]private BaseCounter baseCounter;
    // can be added array
    [SerializeField]private GameObject visualGameObject;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }   

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
       if(e.selectedCounter == baseCounter)
       {
            Show(); Debug.Log("show");
       }
       else
       {
            Hide();
       }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }
        private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}