using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField]
    private float range; //���� ������ �ִ� �Ÿ�.
    private bool pickupActivated = false; //���� ������ �ÿ��� Ȱ��ȭ(true)

    private RaycastHit hitInfo; //�浹ü ���� ����
    [SerializeField]
    private LayerMask layerMask; //�����ۿ� ���� ���̾�� �����ϵ��� ���̾� ����ũ�� ����

    [SerializeField]
    private Text actionText; //~�� ȹ���Ͻðڽ��ϱ�?���� ~�� �ش�(�ʿ��� ������Ʈ)

    private void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction() //������ �ݱ� �ൿ
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CheckItem() //�������� �ִ��� üũ
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        { //transform.forward : �÷��̾ �ٶ󺸴� x�� ����(=transform.TransformDirection(Vector3.forward)
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
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� " + "<color=yellow>" + "(E)" + "</color>"; //(E)�� ��������� ĥ����
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
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ���߽��ϴ�."); //���� �κ��丮�� �����Ƿ� �ӽ÷� ����׷� ���ڿ� ���
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }
}
