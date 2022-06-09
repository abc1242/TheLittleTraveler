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
        float mouseX = Input.GetAxis("Mouse X");    // 마우스 좌/우 움직임
        float mouseY = Input.GetAxis("Mouse Y");    // 마우스 위/아래 움직임

        cameraController.RotateTo(mouseX, mouseY);
    }
}
