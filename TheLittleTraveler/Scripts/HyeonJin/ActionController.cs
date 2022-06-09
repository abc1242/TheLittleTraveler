using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range; //습득 가능한 최대 거리.
    private bool pickupActivated = false; //습득 가능할 시에는 활성화(true)

    public static RaycastHit hitInfo; //충돌체 정보 저장
    [SerializeField]
    private LayerMask layerMask; //아이템에 대한 레이어에만 반응하도록 레이어 마스크를 설정

    [SerializeField]
    private Text actionText; //~를 획득하시겠습니까?에서 ~에 해당(필요한 컴포넌트)
    [SerializeField]
    private Text digText; //파자!

    [SerializeField]
    private Inventory theInventory;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    public Text waterTxt;
    [SerializeField]
    public int waterCnt;
    [SerializeField]
    public Text scissorsTxt;
    [SerializeField]
    public int scissorsCnt;


    DialogueManager theDM;

    public static string target = "";
    public static int toolCnt = 0;

    bool IsPickUp = true;

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        waterCnt = 0;
        scissorsCnt = 0;
    }

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

            //제거한 부분
            //CanPickUp();

            //수정한 부분
            //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
            if (hitInfo.transform != null)
            {
                float distance = Vector3.Distance(player.transform.position, hitInfo.transform.position);
                if (distance < range)
                {
                    if (hitInfo.transform.tag == "AirportItem")
                    {
                        CanPickUp();
                    }
                    //else if (hitInfo.transform.tag == "CampFire")
                    //{
                    //hitInfo.transform.GetComponent<CampFire>().lookAtFire();
                    //Debug.Log("불멍시작!");
                    //}
                    else if (hitInfo.transform.tag == "Rock")
                    {
                        hitInfo.transform.GetComponent<Rock>().Mining();
                        Debug.Log("깨져라!");

                    }
                    else if (hitInfo.transform.tag == "Sand")
                    {
                        hitInfo.transform.GetComponent<PileOfSand>().Digging();
                        Debug.Log("파자!");
                    }


                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.F) && !DialogueManager.isDialogue)
        {
            CheckItem();

            if (hitInfo.transform != null)
            {
                float distance = Vector3.Distance(player.transform.position, hitInfo.transform.position);
                if (distance < range)
                {
                    if (hitInfo.transform.tag == "NPC")
                    {
                        StartCoroutine(WaitCollision());
                    }
                }
            }
        }
    }

    private void CheckItem() //아이템이 있는지 체크
    {
        //Debug.Log("이거 실행중");
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        { //transform.forward : 플레이어가 바라보는 x축 방향(=transform.TransformDirection(Vector3.forward)

            if (hitInfo.transform.tag == "AirportItem")
            {
                ItemInfoAppear();
            }
            else if (hitInfo.transform.tag == "Rock" || hitInfo.transform.tag == "Sand")
            {
                NatureAppear();
            }
            else if (hitInfo.transform.tag == "NPC")
            {
                target = hitInfo.transform.name;
                TalkNPC();
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
        digText.gameObject.SetActive(false);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>"; //(E)는 노란색으로 칠해짐
    }

    private void NatureAppear()
    {
        digText.gameObject.SetActive(true);
        if (hitInfo.transform.tag == "Rock")
        {
            digText.text = "깨자! " + "<color=yellow>" + "(E)" + "</color>"; //(E)는 노란색으로 칠해짐
        }
        else if (hitInfo.transform.tag == "Sand")
        {
            digText.text = "파자! " + "<color=yellow>" + "(E)" + "</color>"; //(E)는 노란색으로 칠해짐
        }
    }

    private void TalkNPC()
    {
        float distanceNPC = Vector3.Distance(player.transform.position, hitInfo.transform.position);
        if(distanceNPC < range)
        {
            if (hitInfo.transform.tag == "NPC")
            {
                digText.gameObject.SetActive(true);
                digText.text = "대화하기!" + "<color=yellow>" + "(F)" + "</color>";
            }
        }else
        {
            digText.gameObject.SetActive(false);
        }
    }

    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
        digText.gameObject.SetActive(false);
        IsPickUp = true;
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null && IsPickUp)
            {
                IsPickUp = false;
                if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "전지가위")
                {
                    scissorsTxt.text = "<color=#78FF79>" + "전지가위 획득" + "</color>";
                     scissorsCnt += 1;
                }
                if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "물뿌리개")
                {
                    waterTxt.text = "<color=#78FF79>" + "물뿌리개 획득" + "</color>";
                    waterCnt += 1;
                }
                if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "나사" ||
                    hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "렌치")
                {
                    toolCnt += 1;
                }
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득했습니다."); //아직 인벤토리가 없으므로 임시로 디버그로 문자열 출력
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("물고기")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("문어")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("오징어")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("물개")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("OrangeJellyfish")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("BlueJellyfish")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("WhiteJellyfish")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("상어")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("펭귄")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("고래")
                    || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName.Equals("악어"))
                {
                    hitInfo.transform.GetChild(2).gameObject.SetActive(true);
                }
                else if(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "전지가위" || hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "물뿌리개")
                {
                    hitInfo.transform.GetChild(3).gameObject.SetActive(true);
                }
                else
                {
                    hitInfo.transform.GetChild(0).gameObject.SetActive(true);
                }
                Destroy(hitInfo.transform.gameObject, 0.5f);
                Invoke("InfoDisappear", 0.5f);
            }
        }
    }

    IEnumerator WaitCollision()
    {
        // yield return new WaitForSeconds(1);
        yield return 1;

        theDM.ShowDialogue(hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue());
    }
}