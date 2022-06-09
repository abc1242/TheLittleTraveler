using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{

    Animator _animator;
    Camera _camera;
    CharacterController _controller;

    public float speed = 3f;
    public float runSpeed = 8f;
    public float finalSpeed;
    public float smoothness = 10f;
    public float gravity = -9.81f;
    public float jumpForce = 3.0f;
    public bool toggleCameraRotation;
    public bool run;
    private Vector3 moveDir;


    public GameObject sheep;
    public GameObject player;

    public bool move_start;

    // Start is called before the first frame update
    void Start()
    {

        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();


        sheep = GameObject.Find("sheep");
        player = GameObject.Find("Player");

        move_start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.canPlayerMove)
        {
            if (_animator.GetBool("Mount"))
            {
                smoothness = 0.0f;
            }
            else
            {
                smoothness = 10.0f;
                _camera = Camera.main;

                if (_controller.isGrounded == false)
                {
                    moveDir.y += gravity * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.LeftAlt))
                {
                    toggleCameraRotation = true;
                }
                else
                {
                    toggleCameraRotation = false;
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    run = true;
                }
                else
                {
                    run = false;
                }
                InputMovement();
                if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
                {
                    moveDir.y = jumpForce;
                    _animator.SetBool("Jump", true);
                }
                //if (_controller.isGrounded == true)
                else
                {
                    _animator.SetBool("Jump", false);
                }
            }
        }


    }
    void LateUpdate()
    {

        if (toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
    }

    private void FixedUpdate()
    {
        if (move_start == true)
        {
            player.transform.position = new Vector3(0, 5, -2.5f);
        }

    }
    void InputMovement()
    {
        finalSpeed = (run) ? runSpeed : speed;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");
        moveDir = new Vector3(moveDirection.x, moveDir.y, moveDirection.z);

        _controller.Move(moveDir * finalSpeed * Time.deltaTime);

        _animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"), 0.1f, Time.deltaTime);

        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
        _animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
    }



    private void OnTriggerStay(Collider other)
    {
       



        if(other.gameObject.name == "sheep")
        {
            jumpForce = 3;
            if (Input.GetKey(KeyCode.E))
            {
                DontDestroyOnLoad(sheep);
                LoadingSceneController.LoadScene("KisungB612Test_back", 1);

            }
        }

        if (other.gameObject.name == "ladder-wood")
        {
            jumpForce = 3;
            if (Input.GetKey(KeyCode.E))
            {
                LoadingSceneController.LoadScene("KisungB612Test_back", 1);

            }
        }

        if (other.gameObject.name == "boong1")
        {
            Debug.Log("∫ÿ¡°«¡");
            jumpForce = 4;

        }


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Plane")
        {
            Debug.Log("¿Ãµø");
            jumpForce =3;
            //player.transform.position = new Vector3(0, 3, -2.5f);
            move_start = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        move_start = false;
    }

}
