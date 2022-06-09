using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField]
    private float range; //습득 가능한 최대 거리.
    private bool pickupActivated = false; //습득 가능할 시에는 활성화(true)

    private RaycastHit hitInfo; //충돌체 정보 저장
    [SerializeField]
    private LayerMask layerMask; //아이템에 대한 레이어에만 반응하도록 레이어 마스크를 설정

    [SerializeField]
    private Text actionText; //~를 획득하시겠습니까?에서 ~에 해당(필요한 컴포넌트)

    private void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction() //아이템 줍기 행동
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CheckItem() //아이템이 있는지 체크
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        { //transform.forward : 플레이어가 바라보는 x축 방향(=transform.TransformDirection(Vector3.forward)
            if (hitInfo.transform.tag == "AirportItem")
            {
                ItemInfoAppear();
            }
        }
        else
        {
            InfoDisappear();
        }
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>"; //(E)는 노란색으로 칠해짐
    }

    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득했습니다."); //아직 인벤토리가 없으므로 임시로 디버그로 문자열 출력
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }
}
