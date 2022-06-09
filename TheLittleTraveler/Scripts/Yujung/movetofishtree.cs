using UnityEngine;
using UnityEngine.UI;

public class movetofishtree : MonoBehaviour
{
    [SerializeField]
    private GameObject player; //캐릭터
    [SerializeField]
    private GameObject move; //자기 자신(장미)
    [SerializeField]
    private float range; //비행기와 캐릭터 사이 거리

    [SerializeField]
    private Text moveText; //이동할 메시지 띄울 오브젝트
    [SerializeField]
    private string text; //메시지 내용
    [SerializeField]
    private string sceneName; //씬이름
    [SerializeField]
    private int num; //로딩씬 번호

    private void Update()
    {
        MoveToByKeyCode();
    }

    private void MoveToByKeyCode() //키보드를 통해 이동할 경우
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
                LoadingSceneController.LoadScene(sceneName, num); //지정한 씬으로 이동, 로딩씬 번호
            }

        }
        else
        {
           moveText.gameObject.SetActive(false);
        }

    }
}


