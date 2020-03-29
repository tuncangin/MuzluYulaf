using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController controller; 
    float moveSpeed = 3f;
    public float gravity = -9.81f;
    Vector3 velocity;
    bool isGrounded;
    public float jumpHeight = 1f;
    public Transform groundChecker;
    bool jump;
    

    public LayerMask groundLayer;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()


    {
        isGrounded = Physics.CheckSphere(groundChecker.position, 0.3f,groundLayer);
        if (isGrounded)
            jump = false;

        if(velocity.y <0 && isGrounded)
        {
            velocity.y = -2f;
        }

        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * 5);
        }

        if (Input.GetKey(KeyCode.LeftShift)  && z>0 && !jump)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 9f, 2 * Time.deltaTime);
        }
        else 
            moveSpeed = Mathf.Lerp(moveSpeed, 3f, 2*Time.deltaTime);

    }

    
}
