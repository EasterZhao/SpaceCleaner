using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActons playerInputActons;
    private void Awake() {
        playerInputActons = new PlayerInputActons();
        playerInputActons.Player.Enable();
        playerInputActons.Player.Interact.performed += Interact_performed;
    }
    // if Player pressed E
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this,EventArgs.Empty);

    }
    
    
    public Vector2 GetMovementVectorNormalized()
         {
         Vector2 inputVector = playerInputActons.Player.Move.ReadValue<Vector2>();
        // a vector keeps the same direction but its length is 1.0
        inputVector = inputVector.normalized; 
        return inputVector;
    }
}
