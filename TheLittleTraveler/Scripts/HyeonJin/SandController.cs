using UnityEngine;

public class SandController : MonoBehaviour
{
    [SerializeField]
    private GameObject player; //ĳ����
    [SerializeField]
    private GameObject sand; //�ڱ� �ڽ�(�� ����)
    [SerializeField]
    private GameObject effect; //ȿ��
    [SerializeField]
    private float range; //ȿ���� ���̴� �ִ� �Ÿ�.

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance() //ĳ���Ϳ��� �Ÿ� üũ
    {
        float distance = Vector3.Distance(player.transform.position, sand.transform.position);
        if (distance < range)
        {
            EffectAppear();
        }
        else
        {
            EffectDisappear();
        }
    }


    private void EffectAppear()
    {
        effect.SetActive(true);
    }

    private void EffectDisappear()
    {
        effect.SetActive(false);
    }
}
