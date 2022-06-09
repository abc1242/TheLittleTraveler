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
    public GameObject background1; //�ε� ȭ�� 1
    [SerializeField]
    public GameObject background2; //�ε� ȭ�� 2
    [SerializeField]
    public GameObject background3; //�ε� ȭ�� 3

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }

    [SerializeField]
    public GameObject background4; //�ε� ȭ�� 4F
    static int SceneNum;

    public static void LoadScene(string sceneName, int num)
    {
        nextScene = sceneName;
        SceneNum = num;
        SceneManager.LoadScene("LoadingScene"); //LoadingScene �ҷ�����(static ���� �����صױ� ������ ��𼭵� Ŭ���� �̸����� ȣ�Ⱑ��)
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess() //LoadSceneProcess �Լ�
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
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); //�񵿱� ������� ���� �ҷ��´�.
        //���� �񵿱Ⱑ ���� �� �ڵ����� �ش� ������ �̵����� ���� ����
        op.allowSceneActivation = false; //false�� �����صθ� 90%������ load�� ���·� ���� ������ �Ѿ�� ����
        //�� �ε� �ӵ��� �����ϰ� �ε�ȭ�鿡�� �ҷ��;� �ϴ� ���� Scene�� �� �ƴϱ⿡ false�� ����(����ũ ����)

        float timer = 0f; //�ð� ���� ����
        float progressBar = 0f;
        while (!op.isDone) //�� �ε��� ���� ����� ���� ���¶�� �ݺ�
        {
            yield return null; //�ݺ��� ������ unityengine�� ������� �ѱ� -> �ݺ����� ������ ���� ȭ�� ���ŵ��� �ʾ� ����� ���� �� �� ���� �� ����

            if (op.progress < 0.9f) //�ε� ���൵ 90%���� ��á�ٸ�
            {
                progressBar = op.progress; //�ε� ���൵ ǥ��
            }
            else //����ũ �ε� ����
            {
                timer += Time.unscaledDeltaTime;

                progressBar = Mathf.Lerp(0.9f, 1f, timer); //0.9���� 1�� 1�ʿ� ���ļ� ä��
                if (progressBar >= 1f) //100% ä�����ٸ� �� �ҷ�����
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
