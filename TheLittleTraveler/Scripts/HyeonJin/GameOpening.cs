using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOpening : MonoBehaviour
{
    //[SerializeField]
    //string sceneName;

    /* private void Update()
     {
         if (Input.GetMouseButtonDown(0)) //0: 좌클릭, 1: 우클릭, 2: 중앙
         {
             LoadingSceneController.LoadScene(sceneName);
         }
     } */

    [SerializeField]
    private GameObject tutorialImg; //튜토리얼 이미지
    [SerializeField]
    int num; //씬 숫자

    private void Awake()
    {
        tutorialImg.SetActive(false); //처음 게임 시작 시 튜토리얼 창 상태 false 로 설정
    }

    public void OnClickStartBtn() //게임 시작 버튼
    {
        LoadingSceneController.LoadScene("YoungbinTimelineB612", num); //게임 첫 시작 화면 씬 이름
    }

    public void OnClickTutorialBtn() //튜토리얼 버튼
    {
        //튜토리얼 버튼 클릭 시 튜토리얼 상태에 따라 함수 실행
        if (!tutorialImg.activeSelf)
        {
            tutorialImg.SetActive(true); //튜토리얼 창 열기
        }
        else
        {
            tutorialImg.SetActive(false); //튜토리얼 창 닫기
        }
    }
}