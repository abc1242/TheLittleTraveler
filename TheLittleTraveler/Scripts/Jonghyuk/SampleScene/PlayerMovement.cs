using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
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

    //int count = 0;
    //public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();
        //countText.text = "Count:" + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.canPlayerMove)
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
        if(toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
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

    private void OnTriggerEnter(Collider starcoin)
    {
        if(starcoin.gameObject.CompareTag("PickUp"))
        {
            Destroy(starcoin.gameObject);
            GameObject.Find("star_count_obj").GetComponent<CountingStar>().star_cnt += 1;
            if(PlayerQuest_Desert.Desert)
            {
                CountingStar.star_cnt_desert += 1;
                if (CountingStar.star_cnt_desert < 10)
                {
                    GameObject.Find("PlayerTest").GetComponent<PlayerQuest_Desert>().starHint_desert.text = "<color=#FFFE77>" + "�縷 " + CountingStar.star_cnt_desert + "/10" + "</color>";
                }
                else
                {
                    GameObject.Find("PlayerTest").GetComponent<PlayerQuest_Desert>().starHint_desert.text = "<color=#78FF79>" + "�縷�� �� ������ �Ϸ�!" + "</color>";
                }
            }
            if(PlayerQuest_Forest.Forest)
            {
                CountingStar.star_cnt_forest += 1;
                if (CountingStar.star_cnt_forest < 7)
                {
                    GameObject.Find("Player").GetComponent<PlayerQuest_Forest>().starHint_forest.text = "<color=#FFFE77>" + "�ʿ� " + CountingStar.star_cnt_forest + "/7" + "</color>";
                }
                else
                {
                    GameObject.Find("Player").GetComponent<PlayerQuest_Forest>().starHint_forest.text = "<color=#78FF79>" + "�ʿ��� �� ������ �Ϸ�!" + "</color>";
                }
            }
            //countText.text = "Count:" + count.ToString();
            if (GameObject.Find("PlayerTest") != null)
                {
            GameObject.Find("PlayerTest").GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.Find("Player").GetComponent<AudioSource>().Play();
            }
        }
    }
   
}
