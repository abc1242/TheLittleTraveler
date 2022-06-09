using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterectionController : MonoBehaviour
{

    [SerializeField] Camera cam;

    RaycastHit hitInfo;

    bool isContect = false;

    public static bool isInteract = false;

    DialogueManager theDM;

    void Start(){
        Debug.Log("실행확인");
        theDM = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        CheckObject();
        ClickLeftBtn();
    }

    void CheckObject(){
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, 100)){
            Contact();
        }else{
            NotContact();
        }
    }

    void Contact(){
        // Debug.Log("접촉확인");
        if (hitInfo.transform.CompareTag("Interaction"))
        {
            if(!isContect){
                isContect = true;
            }
        }
    }

    void NotContact(){
        if (isContect)
        {
            isContect = false;
        }
    }

    void ClickLeftBtn(){
        // Debug.Log("클릭확인");
        // 마우스 좌클릭을 감지했을때
        if (Input.GetMouseButtonDown(0))
        {
            if(isContect){
                Interact();
            }
        }
    }

    void Interact(){
        isInteract = true;
        StartCoroutine(WaitCollision());
    }

    IEnumerator WaitCollision(){
        yield return new WaitForSeconds(1);

        theDM.ShowDialogue(hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue());
    }
}
