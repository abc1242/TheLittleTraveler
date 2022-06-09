using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<FirstController>().enabled = true;
            gameObject.GetComponent<CameraMovement>().enabled = true;
        }
        float mouseX = Input.GetAxis("Mouse X");    // ���콺 ��/�� ������
        float mouseY = Input.GetAxis("Mouse Y");    // ���콺 ��/�Ʒ� ������

        cameraController.RotateTo(mouseX, mouseY);
    }
}
