using UnityEngine;
using UnityEngine.UI;

public class FinToOtherPlanet : MonoBehaviour
{
    [SerializeField]
    private GameObject player; //캐릭터
    [SerializeField]
    private GameObject move; //자기 자신
    [SerializeField]
    private float range; //비행기와 캐릭터 사이 거리

    [SerializeField]
    private Text finText; //이동할 메시지 띄울 오브젝트

    private void Update()
    {
        MoveToByKeyCode();
    }

    private void MoveToByKeyCode()
    {
        if (!PlayerQuest_Desert.DesertQuestEnd && PlayerQuest_Desert.Desert)
        {
            finText.gameObject.SetActive(false);
            return;
        }
        float distance = Vector3.Distance(player.transform.position, move.transform.position);
        if (distance < range)
        {
            finText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                LoadingSceneController.LoadScene("EndingScene", 1);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                LoadingSceneController.LoadScene("KisungB612Test_back", 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                LoadingSceneController.LoadScene("YB_lowpoly_back", 2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                LoadingSceneController.LoadScene("YUDesert_back", 4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && !SsafyPlanet.ssafyCnt)
            {
                LoadingSceneController.LoadScene("SSAFYPlanet", 3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && SsafyPlanet.ssafyCnt)
            {
                LoadingSceneController.LoadScene("SSAFYPlanet_back", 1);
            }

        }
        else
        {
            finText.gameObject.SetActive(false);
        }

    }
}
