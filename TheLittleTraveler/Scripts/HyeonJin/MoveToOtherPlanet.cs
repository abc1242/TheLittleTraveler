using UnityEngine;
using UnityEngine.UI;

public class MoveToOtherPlanet: MonoBehaviour
{
    [SerializeField]
    private GameObject player; //캐릭터
    [SerializeField]
    private GameObject move; //자기 자신
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
    [SerializeField]
    private KeyCode keyCode; // keycode 번호

    private void Update()
    {
        MoveToByKeyCode();
    }

    private void MoveToByKeyCode() //키보드를 통해 이동할 경우
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
                LoadingSceneController.LoadScene("YB_lowpoly_back", 4); //지정한 씬으로 이동, 로딩씬 번호
            }
        }
        if (PlayerQuest_Forest_Back.Forest_back && PlayerQuest_Desert.DesertQuestEnd)
        {
            moveText.gameObject.SetActive(true);
            moveText.text = text;
            if (Input.GetKeyDown(keyCode))
            {
                LoadingSceneController.LoadScene("YUDesert_back", 2); //지정한 씬으로 이동, 로딩씬 번호
            }
        }


        float distance = Vector3.Distance(player.transform.position, move.transform.position);
        if (distance < range)
        {
            moveText.gameObject.SetActive(true);
            moveText.text = text;
            if (Input.GetKeyDown(keyCode))
            {
                LoadingSceneController.LoadScene(sceneName, num); //지정한 씬으로 이동, 로딩씬 번호
            }

        }else
        {
            moveText.gameObject.SetActive(false);
        }
        
    }
}
