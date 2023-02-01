using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    private Animator animator;


    private bool isWalking;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        if(Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        // a vector keeps the same direction but its length is 1.0.
        inputVector = inputVector.normalized;
        // Limit Y-axis movement to 0.
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //Sleek turnaround.Vector3 Slerp(Vector3 a, Vector3 b, float t);
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDir, Time.deltaTime * rotateSpeed );
        

        if(moveDir != Vector3.zero)
        {
            animator.SetBool("IsWalking",true);
        }
        else
        {
            animator.SetBool("IsWalking",false);
        }
        
    }   
}
