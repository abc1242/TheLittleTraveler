using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePrinceCamera : MonoBehaviour
{
    float mouseY = 0;
    float mouseSpeed = 5;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.cameraMove)
        {
            mouseY += Input.GetAxis("Mouse Y") * mouseSpeed;
            mouseY = Mathf.Clamp(mouseY, -30.0f, 60.0f);
            transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
        }
    }


}
