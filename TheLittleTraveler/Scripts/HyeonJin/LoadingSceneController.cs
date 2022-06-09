using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;
    [SerializeField]
    public GameObject background1; //로딩 화면 1
    [SerializeField]
    public GameObject background2; //로딩 화면 2
    [SerializeField]
    public GameObject background3; //로딩 화면 3

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }

    [SerializeField]
    public GameObject background4; //로딩 화면 4F
    static int SceneNum;

    public static void LoadScene(string sceneName, int num)
    {
        nextScene = sceneName;
        SceneNum = num;
        SceneManager.LoadScene("LoadingScene"); //LoadingScene 불러오기(static 으로 선언해뒀기 때문에 어디서든 클래스 이름으로 호출가능)
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess() //LoadSceneProcess 함수
    {
        switch(SceneNum)
        {
            case 1:
                background1.SetActive(true);
                break;
            case 2:
                background2.SetActive(true);
                break;
            case 3:
                background3.SetActive(true);
                break;
            case 4:
                background4.SetActive(true);
                break;
        }
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); //비동기 방식으로 씬을 불러온다.
        //씬의 비동기가 끝날 때 자동으로 해당 씬으로 이동할지 설정 여부
        op.allowSceneActivation = false; //false로 설정해두면 90%까지만 load한 상태로 다음 씬으로 넘어가지 않음
        //씬 로딩 속도를 조절하고 로딩화면에서 불러와야 하는 것이 Scene만 이 아니기에 false로 설정(페이크 설정)

        float timer = 0f; //시간 측정 변수
        float progressBar = 0f;
        while (!op.isDone) //씬 로딩이 아직 종료된 않은 상태라면 반복
        {
            yield return null; //반복될 때마다 unityengine에 제어권을 넘김 -> 반복문이 끝나기 전에 화면 갱신되지 않아 진행바 상태 볼 수 없을 수 있음

            if (op.progress < 0.9f) //로딩 진행도 90%까지 안찼다면
            {
                progressBar = op.progress; //로딩 진행도 표시
            }
            else //페이크 로딩 설정
            {
                timer += Time.unscaledDeltaTime;

                progressBar = Mathf.Lerp(0.9f, 1f, timer); //0.9에서 1로 1초에 걸쳐서 채움
                if (progressBar >= 1f) //100% 채워졌다면 씬 불러오기
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
