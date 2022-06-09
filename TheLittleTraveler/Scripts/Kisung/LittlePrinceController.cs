

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LittlePrinceController : MonoBehaviour
{

    public  bool rose_enable;
    public  bool volcano1_enable;
    public  bool volcano2_enable;
    public  bool baobab_enable;

    public float speed = 3f;
    public float runSpeed = 8f;
    public float finalSpeed;
    public float jumpForce = 5.0f;

    private Rigidbody rigid;//어린왕자 
    private Vector3 moveDir;
    float h, v;//어린왕자 이동wasd
    public float turnSpeed = 500.0f;//마우스 좌우회전속도

    //장미 충돌 구현
    public GameObject rose;

    //바오밥
    public GameObject baobab;

    //화산연기
    public GameObject smoke1;
    public GameObject smoke2;
    int num;

    //애니메이션
    private Animator anim;


    //양
    public GameObject sheep;

    public bool run;
    public bool isGrounded;

    //public float gravity = -9.81f;

    public bool cam3;//true일때 3인칭
    public Camera FirstCamera;
    public Camera ThirdCamera;

    private void Start()
    {

        jumpForce = 5.0f;
        rigid = GetComponent<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();
        rose = GameObject.Find("rose");

        smoke1 = GameObject.Find("smoke_01");
        smoke2 = GameObject.Find("smoke_02");

        baobab = GameObject.Find("BaobabTree");

        //카메라
        cam3 = true;
        FirstCamera.enabled = false;
        ThirdCamera.enabled = true;

        rose_enable = false;
        volcano1_enable = false;
        volcano2_enable = false;
        baobab_enable = false;

        if (GameObject.Find("sheep") != null)
        {
            sheep = GameObject.Find("sheep");
            sheep.transform.position = new Vector3(0, 25, -3);
            sheep.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
    }

    //이동구현
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(cam3 == true)
            {
                cam3 = false;
                FirstCamera.enabled = true;
                ThirdCamera.enabled = false;
            }
            else
            {
                cam3 = true;
                FirstCamera.enabled = false;
                ThirdCamera.enabled = true;
            }
        }

        if (GameManager.canPlayerMove)
        {
            speed = 3f;
            runSpeed = 8f;
            jumpForce = 5.0f;
            //이동
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            moveDir = new Vector3(h, 0, v).normalized;


            float turn = Input.GetAxis("Mouse X");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

            //애니메이션


            anim.SetFloat("Horizontal", h, 0.1f, Time.deltaTime);

            float percent = ((run) ? 1 : 0.5f) * moveDir.magnitude;
            anim.SetFloat("Blend", percent, 0.1f, Time.deltaTime);

            //상태변화
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run = true;
            }
            else
            {
                run = false;
            }
        }
        else
        {
            speed = 0;
            runSpeed = 0;
            jumpForce = 0;
        }
        

    }

    private void FixedUpdate()
    {
        finalSpeed = (run) ? runSpeed : speed;
        rigid.MovePosition(rigid.position + transform.TransformDirection(moveDir * finalSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            anim.SetBool("Jump", true);

            rigid.AddForce(transform.TransformDirection(new Vector3(0, 1, 0) * jumpForce), ForceMode.Impulse);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }


    //충돌 이벤트 구현
    // 장미 키우기
    private void OnCollisionStay(Collision collision)
    {
        //아이템인 경우 줍기
        if (Input.GetKey(KeyCode.E) && (collision.gameObject.name == "WateringCanItem" || collision.gameObject.name.Equals("ScissorItem"))) //E버튼 클릭
        {
            CanPickUp(collision.gameObject);
        }

        if (collision.gameObject.name == "rose")
        {
            rose_enable = true;
        }

        if (collision.gameObject.name == "Volcano_01")
        {
            volcano1_enable = true;
        }

        if (collision.gameObject.name == "Volcano_02")
        {
            volcano2_enable = true;
        }


        if (collision.gameObject.name == "baobabTree_01")
        {
            baobab_enable = true;
        }


        //땅인지 체크
        if (collision.gameObject.name == "b612")
        {
            isGrounded = true;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "b612")
        {
            isGrounded = false;

        }

        if (collision.gameObject.name == "Volcano_01")
        {
            volcano1_enable = false;

        }

        if (collision.gameObject.name == "Volcano_02")
        {
            volcano2_enable = false;

        }

        if (collision.gameObject.name == "rose")
        {
            rose_enable = false;
        }

        if (collision.gameObject.name == "baobabTree_01")

        {
            baobab_enable = false;
        }



    }

    private void OnTriggerEnter(Collider starcoin)
    {
        if (starcoin.gameObject.CompareTag("PickUp"))
        {
            starcoin.gameObject.SetActive(false);

            GameObject.Find("star_count_obj").GetComponent<CountingStar>().star_cnt += 1;
            if (B612Animation.B612)
            {
                CountingStar.star_cnt_b612 += 1;
            }
            GameObject.Find("Player").GetComponent<AudioSource>().Play();
        }
    }

    private void ChangePositionY(GameObject obj)
    {
        while (obj.transform.GetChild(0).transform.position.y > 1.0f)
        {
            obj.transform.GetChild(0).transform.Translate(Vector3.down);
            //Debug.Log(obj.transform.GetChild(0).transform.position.y);
        }
    }

    //현진 추가 함수
    IEnumerator TimeDelayItem(GameObject obj, int num)
    {
        yield return new WaitForSeconds(5.0f);
        obj.transform.GetChild(num).gameObject.SetActive(true);
    }
    private void CanPickUp(GameObject collision)
    {
        if (collision.transform != null)
         {
            Destroy(collision.transform.gameObject, 0.5f);
        }
    }
}

