using UnityEngine;
using UnityEngine.UI;

public class movetofishtree : MonoBehaviour
{
    [SerializeField]
    private GameObject player; //ĳ����
    [SerializeField]
    private GameObject move; //�ڱ� �ڽ�(���)
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

    private void Update()
    {
        MoveToByKeyCode();
    }

    private void MoveToByKeyCode() //Ű���带 ���� �̵��� ���
    {
        if (!PlayerQuest_Desert.DesertQuestEnd && PlayerQuest_Desert.Desert)
        {
            moveText.gameObject.SetActive(false);
            return;
        }
        float distance = Vector3.Distance(player.transform.position, move.transform.position);
        if (distance < range)
        {
            moveText.gameObject.SetActive(true);
            moveText.text = text;
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadingSceneController.LoadScene(sceneName, num); //������ ������ �̵�, �ε��� ��ȣ
            }

        }
        else
        {
           moveText.gameObject.SetActive(false);
        }

    }
}


