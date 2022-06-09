using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;

    // ĳ���� ��Ʈ�ѷ� ������Ʈ ����
    CharacterController cc;

    float gravity = -20f;
    // ���� �ӷ� ����
    float yVelocity = 0;

    // �÷��̾� ü��
    //public int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        // ���� ī�޶� �������� ������ ����
        dir = Camera.main.transform.TransformDirection(dir);

        transform.position += dir * moveSpeed * Time.deltaTime;

        // �����ӵ��� �߷� �� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // �̵� �Լ�
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }

    // �ٸ� ��ũ��Ʈ���� �����ϱ� ������ public �߰�
    //public void DamageAction(int damage)
    //{
        //hp -= damage; // 10 -> 7 -> 4 -> 1 -> -2, ü���� ������ �Ǹ� �ٷ� 0����
        //if (hp < 0)
        //{
            //hp = 0;
        //}
        //print(hp);
    //}
}
