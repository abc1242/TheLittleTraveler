using UnityEngine;
using UnityEngine.UI;
using System;

public class FishingHandsController : MonoBehaviour
{
    [SerializeField]
    private GameObject player_basic;
    [SerializeField]
    private GameObject player_fishing;
    [SerializeField]
    private Text fishText;
    [SerializeField]
    private Text actionText;

    Animator _animator;

    //���� �� �ִ� ������
    [SerializeField]
    private GameObject fish; //�����
    [SerializeField]
    private GameObject octopus; //����
    [SerializeField]
    private GameObject squid; //��¡��
    [SerializeField]
    private GameObject seal; //����
    [SerializeField]
    private GameObject frog; // ������
    [SerializeField]
    private GameObject orangejellyfish; // �����ǽ�
    [SerializeField]
    private GameObject bluejellyfish;
    [SerializeField]
    private GameObject whitejellyfish;
    [SerializeField]
    private GameObject shark; // ���
    [SerializeField]
    private GameObject penguin; // ���
    [SerializeField]
    private GameObject crocodile; // �Ǿ�
    [SerializeField]
    private GameObject whale; // ��


    // Start is called before the first frame update
    void Start()
    {
        _animator = player_fishing.GetComponent<Animator>();

    }

    void Update()
    {
        //float distance = Vector3.Distance(player_basic.transform.position, test.transform.position);
        //Debug.Log(player_basic.transform.position);

        if (Mathf.Abs(player_basic.transform.rotation.y) >= 0.9
            && player_basic.transform.position.z <= 80 && player_basic.transform.position.z >= 73 // z�� ���� ���� ����
            && player_basic.transform.position.y <= 3 && player_basic.transform.position.y >= 0.7f // y�� ���� ���� ����
            && player_basic.activeSelf //�⺻ ĳ���� Ȱ��ȭ�� ��츸
            )
        {
            fishText.gameObject.SetActive(true);
            fishText.text = "���� ����! " + "<color=yellow>" + "(F)" + "</color>";
            if (Input.GetKeyDown(KeyCode.F))
            {
                fishText.gameObject.SetActive(false);
                player_fishing.transform.SetPositionAndRotation(player_basic.transform.position, player_basic.transform.rotation);
                player_fishing.SetActive(true);
                player_basic.SetActive(false);
                //player_basic.transform.GetChild(0).gameObject.SetActive(false);
                _animator.Play("Srv_FishingStart");
                Invoke("SetActiveStatusDisabled", 20.5f);
            }
        }
        else
        {
            fishText.gameObject.SetActive(false);
        }
    }

    private void SetActiveStatusDisabled()
    {
        player_fishing.SetActive(false);
        player_basic.SetActive(true);
        //player_basic.transform.GetChild(0).gameObject.SetActive(true);

        System.Random random = new System.Random();
        int num = random.Next(12); //12 �̸� ���� �ƴ� ����
        Vector3 newPosition = new Vector3(player_basic.transform.position.x, player_basic.transform.position.y+0.25f, player_basic.transform.position.z-0.5f);
        GameObject copyFish = null;
        switch(num)
        {
            case 0:
                copyFish = Instantiate(fish, newPosition, fish.transform.rotation) as GameObject;
                break;
            case 1:
                copyFish = Instantiate(octopus, newPosition, octopus.transform.rotation) as GameObject;
                break;
            case 2:
                copyFish = Instantiate(squid, newPosition, squid.transform.rotation) as GameObject;
                break;
            case 3:
                copyFish = Instantiate(seal, newPosition, seal.transform.rotation) as GameObject;
                break;
            case 4:
                copyFish = Instantiate(frog, newPosition, frog.transform.rotation) as GameObject;
                break;
            case 5:
                copyFish = Instantiate(orangejellyfish, newPosition, orangejellyfish.transform.rotation) as GameObject;
                break;
            case 6:
                copyFish = Instantiate(bluejellyfish, newPosition, bluejellyfish.transform.rotation) as GameObject;
                break;
            case 7:
                copyFish = Instantiate(whitejellyfish, newPosition, whitejellyfish.transform.rotation) as GameObject;
                break;
            case 8:
                newPosition = new Vector3(player_basic.transform.position.x, player_basic.transform.position.y + 0.4f, player_basic.transform.position.z - 0.5f);
                copyFish = Instantiate(shark, newPosition, shark.transform.rotation) as GameObject;
                break;
            case 9:
                copyFish = Instantiate(penguin, newPosition, penguin.transform.rotation) as GameObject;
                break;
            case 10:
                copyFish = Instantiate(crocodile, newPosition, crocodile.transform.rotation) as GameObject;
                break;
            case 11:
                copyFish = Instantiate(whale, newPosition, whale.transform.rotation) as GameObject;
                break;
        }
        //GameObject copyFish = Instantiate(fish, newPosition, fish.transform.rotation) as GameObject;
        copyFish.SetActive(true);
    }

}
