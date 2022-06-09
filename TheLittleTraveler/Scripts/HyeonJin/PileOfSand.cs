using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileOfSand : MonoBehaviour
{
    [SerializeField]
    private int hp; //모래더미의 체력(0이 되면 파괴)
    [SerializeField]
    private float destroyTime; //모래 제거 시간
    [SerializeField]
    private SphereCollider col; //구체 컬라이더(파괴된 후에는 비활성화시켜서 제거)

    //필요한 게임 오브젝트
    [SerializeField]
    private GameObject pile_of_sand; //모래 더미
    [SerializeField]
    private GameObject go_sand_item_prefab; //모래 더미에 숨겨진 아이템
    [SerializeField]
    private GameObject item_effect; //모래 더미 가리킬 효과
    [SerializeField]
    private GameObject dig_effect; //모래 더미 팔 때 효과

    public void Digging() //파기
    {
        hp--;
        dig_effect.transform.gameObject.SetActive(true);
        Invoke("DisabledDigEffect", 0.3f);
        if (hp <= 0)
        {
            Destruction();
        }
    }

    public void Destruction() //모래 더미 파괴
    {
        col.enabled = false; //콜라이더 비활성화
        Destroy(item_effect); //더미 위치 나타내는 효과 제거

        //채굴되면서 아이템이 생성된다! 이 코드를 여러개 작성 시 그 개수만큼 아이템이 나온다(우리는 1개로 할 듯 하다.)
        //Instantiate(go_sand_item_prefab, pile_of_sand.transform.position, Quaternion.identity);
        go_sand_item_prefab.transform.gameObject.SetActive(true);
        Destroy(pile_of_sand, destroyTime); //모래 더미 제거
    }

    private void DisabledDigEffect()
    {
        dig_effect.transform.gameObject.SetActive(false);
    }


}
