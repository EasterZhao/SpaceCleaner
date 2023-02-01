using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private GameInput gameInput;

    private Animator animator;


    private bool isWalking;

    private Vector3 lastInteractDir;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();

    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        
        float interactDistance = 10f;
        if (Physics.Raycast(transform.position + transform.up * 0.75f, lastInteractDir, out RaycastHit raycastHit, interactDistance))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
        else
        {
            Debug.Log("x");
        }

    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        // Limit Y-axis movement to 0.
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float playerRadius = .5f;
        float playerHeight = 4f;
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        // Sleek turnaround.Vector3 Slerp(Vector3 a, Vector3 b, float t);
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        // Players can slide from the edge when pressing AW, WD, etc. at the same time
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        // Adding character animation
        if (moveDir != Vector3.zero)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
