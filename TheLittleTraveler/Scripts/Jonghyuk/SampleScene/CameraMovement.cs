using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    public GameObject MainCamera;
    public GameObject MainCamera1;
    
    public Transform Player;
    public Transform objectTofollow;
    public float sensitivity = 100f;
    public float clampAngle = 70f;
    
    private float rotX;
    private float rotY;

    // 3인칭
    public Transform realCamera;
    public Vector3 finalDir;
    public float minDistance;
    public float maxDistance;
    public float finalDistance;
    public float smoothness = 10f;

    public bool Third = true;

    void Start()
    {
        Third = true;
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        finalDistance = realCamera.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.cameraMove)
        {
            if (Third == true)
            {
                rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
                rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

                rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
                Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
                transform.rotation = rot;

                ThirdPersonLate();

                if (Input.GetKeyDown(KeyCode.R))
                {
                    AngleEdit();
                    MainCamera.SetActive(false);
                    MainCamera1.SetActive(true);
                    Third = !Third;
                }
            }
            else
            {
                transform.position = Player.transform.position + new Vector3(0, 2, 0);

                float mouseX = Input.GetAxis("Mouse X");    // 마우스 좌/우 움직임
                float mouseY = Input.GetAxis("Mouse Y");    // 마우스 위/아래 움직임


                cameraController.RotateTo(mouseX, mouseY);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    AngleEdit();
                    MainCamera.SetActive(true);
                    MainCamera1.SetActive(false);
                    Third = !Third;
                }
            }
        }
        else
        {
            return;
        }
    }
    void ThirdPersonLate()
    {
        transform.position = Player.transform.position + new Vector3(0, 2, 0);

        RaycastHit hit;

        if (Physics.Linecast(transform.position, finalDir, out hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            finalDistance = maxDistance;
        }
    }

    void AngleEdit()
    {
        rotX = Player.localRotation.eulerAngles.x;
        rotY = Player.localRotation.eulerAngles.y;
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = rot;
    }
}
