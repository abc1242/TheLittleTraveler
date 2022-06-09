using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOpening : MonoBehaviour
{
    //[SerializeField]
    //string sceneName;

    /* private void Update()
     {
         if (Input.GetMouseButtonDown(0)) //0: ��Ŭ��, 1: ��Ŭ��, 2: �߾�
         {
             LoadingSceneController.LoadScene(sceneName);
         }
     } */

    [SerializeField]
    private GameObject tutorialImg; //Ʃ�丮�� �̹���
    [SerializeField]
    int num; //�� ����

    private void Awake()
    {
        tutorialImg.SetActive(false); //ó�� ���� ���� �� Ʃ�丮�� â ���� false �� ����
    }

    public void OnClickStartBtn() //���� ���� ��ư
    {
        LoadingSceneController.LoadScene("YoungbinTimelineB612", num); //���� ù ���� ȭ�� �� �̸�
    }

    public void OnClickTutorialBtn() //Ʃ�丮�� ��ư
    {
        //Ʃ�丮�� ��ư Ŭ�� �� Ʃ�丮�� ���¿� ���� �Լ� ����
        if (!tutorialImg.activeSelf)
        {
            tutorialImg.SetActive(true); //Ʃ�丮�� â ����
        }
        else
        {
            tutorialImg.SetActive(false); //Ʃ�丮�� â �ݱ�
        }
    }
}