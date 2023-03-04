using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnJumpAction;
    private PlayerInputActions playerInputActions;
    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputActions.Player.Jump.performed += Jump_performed;

    }

    // if Player pressed F
    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this,EventArgs.Empty);

    }
    
    // if Player pressed E
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this,EventArgs.Empty);

    }
    // if Player pressed space
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpAction?.Invoke(this,EventArgs.Empty);

    }
    
    public Vector2 GetMovementVectorNormalized()
         {
         Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        // a vector keeps the same direction but its length is 1.0
        inputVector = inputVector.normalized; 
        return inputVector;
    }
}
