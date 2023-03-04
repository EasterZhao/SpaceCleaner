using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour ,ICubeObjectParent
{
    
    public static Player Instance{ get; private set;}
    
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }


    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;

    private Animator animator;


    private bool isWalking;
    private Vector3 lastInteractDir;
    private BaseCounter selectedCounter;
    private CubeObject cubeObject;
    [SerializeField] private Transform cubeObjectHoldPoint;

    private Inventory inventory;

    private Rigidbody sphereRigidbody;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if(Instance != null)
        {
            Debug.LogError("not one instance");

        }
        Instance = this;

        inventory = new Inventory();
        sphereRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();

    }

    private void Start()
    {
        // Player listen to input
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction ;
        gameInput.OnJumpAction += GameInput_OnJumpAction ;
    }
    private void GameInput_OnInteractAlternateAction (object sender, System.EventArgs e)
    {
        // check is there any items on counter
        if (selectedCounter != null)
        {
            selectedCounter.InteractAlternate(this);
        }
    }
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        // check is there any items on counter
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

     private void GameInput_OnJumpAction(object sender, System.EventArgs e)
    {
       Debug.Log("JUMP");
       sphereRigidbody.AddForce(Vector3.up * 20f, ForceMode.Impulse);
    }


    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position + transform.up * 0.75f, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);

        }
        //Debug.Log(selectedCounter);
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        // Limit Y-axis movement to 0.
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float playerRadius = .5f;
        float playerHeight = 4f;
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance, countersLayerMask);

        // Sleek turnaround.Vector3 Slerp(Vector3 a, Vector3 b, float t);
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
         //Players can slide from the edge when pressing AW, WD, etc. at the same time
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance, countersLayerMask);
            isWalking = false;

            if (canMove)
            {
                moveDir = moveDirX;
                isWalking = true;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance, countersLayerMask);

                if (canMove)
                {
                    moveDir = moveDirZ;
                    isWalking = true;
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
            isWalking = true;
        }

        //  Player animation
        if (moveDir != Vector3.zero && isWalking == true)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }

   
    public Transform GetCubeObjectFollowTransform()
    {
        return cubeObjectHoldPoint;
    }

    public void SetCubeObject(CubeObject cubeObject)
    {
        this.cubeObject = cubeObject;
    }

    public CubeObject GetCubeObject()
    {
        return cubeObject;
    }

    public void ClearCubeObject()
    {
          cubeObject = null;
    }

    public bool HasCubeObject()
    {
     return cubeObject != null;
    }
    
  
}
