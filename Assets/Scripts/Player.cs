using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 8f;
    public float walkSpeed = 6f;
    public float gravity = -10f;
    public float jumpHeight = 15f;
    public float groundRayDistance = 1.1f;
    private bool isJumping = false;
    private float currentJumpHeight;


    private CharacterController controller; // Reference to character controller
    private Vector3 motion; // Is the movement offset per frame

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // WASD / Right, Left, Up, Dpwn Arrow Input
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        // Left shift input
        bool inputRun = Input.GetKey(KeyCode.LeftShift);
        // Space bar input
        bool inputJump = Input.GetButtonDown("Jump");
        // Put Horizontal & Vertical input into Vector
        Vector3 inputDir = new Vector3(inputH, 0f, inputV);
        // Rotate direction to players direction
        inputDir = transform.TransformDirection(inputDir);
        // If input exceeds length of >1
        if (inputDir.magnitude > 1f)
        {
            // normaloize it to 1f!
            inputDir.Normalize();
        }


        if (inputRun)
        {
            Run(inputDir.x, inputDir.z);
        }
        else
        {
            Walk(inputDir.x, inputDir.z);
        }

        // If is grounded
        if (controller.isGrounded)
        {
            // .. And jump?
            if (inputJump)
            {
                Jump(jumpHeight);
            }

            // Cancel the Y velocity
            motion.y = 0f;

            // IsGrounded jumping bool set to true
            if (isJumping)
            {
                // Set jump height
                motion.y = currentJumpHeight;
                // Reset back to false
                isJumping = false;
            }

        }

        motion.y += gravity * Time.deltaTime;
        controller.Move(motion * Time.deltaTime);
    }


    void Move(float inputH, float inputV, float speed)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);

        // Convert local direction to world space direction (relative to player's position)
        //direction = transform.TransformDirection(direction);

        motion.x = direction.x * speed;
        motion.z = direction.z * speed;


    }
    public void Walk(float inputH, float inputV)
    {
        Move(inputH, inputV, walkSpeed);
    }
    public void Run(float inputH, float inputV)
    {
        Move(inputH, inputV, runSpeed);
    }
    public void Jump(float height)
    {

        isJumping = true; // We are jumping
        currentJumpHeight = height;
    }
 
}

