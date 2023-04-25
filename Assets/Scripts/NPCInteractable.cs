using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    
    public GameObject hiPanel;
    public GameObject handbook;

    // Called when the NPC is interacted with
    public void Interact()
    {
        // Show the "hi" panel
        hiPanel.SetActive(true);

        // Call the HidePanel method after 4 seconds
        Invoke("HidePanel", 4f);

        handbook.SetActive(true);
    }

    // Hides the "hi" panel
    private void HidePanel()
    {
        hiPanel.SetActive(false);
    }
}
