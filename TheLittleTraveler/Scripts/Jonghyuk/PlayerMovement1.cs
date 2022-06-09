using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    Animator _animator;
    Camera _camera;
    CharacterController _controller;

    public float speed = 3f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public float runSpeed = 8f;
    public float finalSpeed;
    public float smoothness = 10f;
    
    public float jumpForce = 1.0f;
    public bool toggleCameraRotation;
    public bool run;

    public Transform ground_check;
    public float ground_distance = 0.4f;
    public LayerMask ground_mask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("forward", x);
        _animator.SetFloat("strafe", z);


        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if(isGrounded)
        {
            _animator.SetBool("jump", false);
        }
        else
        {
            _animator.SetBool("jump", true); 
        }


        velocity.y += gravity * Time.deltaTime;

        _controller.Move(velocity * Time.deltaTime);

         if (Input.GetKey(KeyCode.LeftAlt))
        {
            toggleCameraRotation = true;
        } 
        else
        {
            toggleCameraRotation = false;
        }
        
        
    }
    void LateUpdate()
    {
        if(toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
    }
    void InputMovement()
    {
        
    }
}
