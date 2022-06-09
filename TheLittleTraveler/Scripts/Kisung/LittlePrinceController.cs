

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

    private Rigidbody rigid;//����� 
    private Vector3 moveDir;
    float h, v;//����� �̵�wasd
    public float turnSpeed = 500.0f;//���콺 �¿�ȸ���ӵ�

    //��� �浹 ����
    public GameObject rose;

    //�ٿ���
    public GameObject baobab;

    //ȭ�꿬��
    public GameObject smoke1;
    public GameObject smoke2;
    int num;

    //�ִϸ��̼�
    private Animator anim;


    //��
    public GameObject sheep;

    public bool run;
    public bool isGrounded;

    //public float gravity = -9.81f;

    public bool cam3;//true�϶� 3��Ī
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

        //ī�޶�
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

    //�̵�����
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
            //�̵�
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            moveDir = new Vector3(h, 0, v).normalized;


            float turn = Input.GetAxis("Mouse X");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

            //�ִϸ��̼�


            anim.SetFloat("Horizontal", h, 0.1f, Time.deltaTime);

            float percent = ((run) ? 1 : 0.5f) * moveDir.magnitude;
            anim.SetFloat("Blend", percent, 0.1f, Time.deltaTime);

            //���º�ȭ
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


    //�浹 �̺�Ʈ ����
    // ��� Ű���
    private void OnCollisionStay(Collision collision)
    {
        //�������� ��� �ݱ�
        if (Input.GetKey(KeyCode.E) && (collision.gameObject.name == "WateringCanItem" || collision.gameObject.name.Equals("ScissorItem"))) //E��ư Ŭ��
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


        //������ üũ
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

    //���� �߰� �Լ�
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

