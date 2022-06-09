using UnityEngine;

public class SandController : MonoBehaviour
{
    [SerializeField]
    private GameObject player; //캐릭터
    [SerializeField]
    private GameObject sand; //자기 자신(모래 더미)
    [SerializeField]
    private GameObject effect; //효과
    [SerializeField]
    private float range; //효과가 보이는 최대 거리.

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance() //캐릭터와의 거리 체크
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
