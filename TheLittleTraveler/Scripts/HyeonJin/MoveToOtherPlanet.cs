using UnityEngine;
using UnityEngine.UI;

public class MoveToOtherPlanet: MonoBehaviour
{
    [SerializeField]
    private GameObject player; //ĳ����
    [SerializeField]
    private GameObject move; //�ڱ� �ڽ�
    [SerializeField]
    private float range; //������ ĳ���� ���� �Ÿ�

    [SerializeField]
    private Text moveText; //�̵��� �޽��� ��� ������Ʈ
    [SerializeField]
    private string text; //�޽��� ����
    [SerializeField]
    private string sceneName; //���̸�
    [SerializeField]
    private int num; //�ε��� ��ȣ
    [SerializeField]
    private KeyCode keyCode; // keycode ��ȣ

    private void Update()
    {
        MoveToByKeyCode();
    }

    private void MoveToByKeyCode() //Ű���带 ���� �̵��� ���
    {

        if (!B612Animation.RoseQuestEnd && B612Animation.B612 || !B612Animation.StarCheck)
        {
            moveText.gameObject.SetActive(false);
            return;
        }
        if (!PlayerQuest_Forest.ForestQuestEnd && PlayerQuest_Forest.Forest)
        {
            moveText.gameObject.SetActive(false);
            return;
        }
        if (!PlayerQuest_Desert.DesertQuestEnd && PlayerQuest_Desert.Desert)
        {
            moveText.gameObject.SetActive(false);
            return;
        }
        if (B612back.B612_back && PlayerQuest_Forest.ForestQuestEnd)
        {
            moveText.gameObject.SetActive(true);
            moveText.text = text;
            if (Input.GetKeyDown(keyCode))
            {
                LoadingSceneController.LoadScene("YB_lowpoly_back", 4); //������ ������ �̵�, �ε��� ��ȣ
            }
        }
        if (PlayerQuest_Forest_Back.Forest_back && PlayerQuest_Desert.DesertQuestEnd)
        {
            moveText.gameObject.SetActive(true);
            moveText.text = text;
            if (Input.GetKeyDown(keyCode))
            {
                LoadingSceneController.LoadScene("YUDesert_back", 2); //������ ������ �̵�, �ε��� ��ȣ
            }
        }


        float distance = Vector3.Distance(player.transform.position, move.transform.position);
        if (distance < range)
        {
            moveText.gameObject.SetActive(true);
            moveText.text = text;
            if (Input.GetKeyDown(keyCode))
            {
                LoadingSceneController.LoadScene(sceneName, num); //������ ������ �̵�, �ε��� ��ȣ
            }

        }else
        {
            moveText.gameObject.SetActive(false);
        }
        
    }
}
