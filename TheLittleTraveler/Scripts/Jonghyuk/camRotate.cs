using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotate : MonoBehaviour
{
    public float rotSpeed = 200f;
    // ȸ�� ���� ������ ����
    // ȭ���� �������� ���� ����
    float mx = 0;
    float my = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 �Է¹ޱ�
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // ȸ�� ���� ����
        Vector3 dir = new Vector3(-mouse_Y, mouse_X, 0);

        // ī�޶� ȸ��
        // transform.eulerAngles += dir * rotSpeed * Time.deltaTime;

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90, 90);
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
