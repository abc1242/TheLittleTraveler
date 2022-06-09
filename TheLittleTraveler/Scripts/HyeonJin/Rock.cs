using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp; //바위의 체력(0이 되면 바위 파괴)
    [SerializeField]
    private float destroyTime; //파편 제거 시간(파편이 영원히 남으면 안되므로)
    [SerializeField]
    private SphereCollider col; //구체 컬라이더(파괴된 후에는 비활성화시켜서 제거)
    
    //필요한 게임 오브젝트
    [SerializeField]
    private GameObject go_rock; //일반 바위
    [SerializeField]
    private GameObject go_debris; //깨진 바위
    [SerializeField]
    private GameObject go_rock_item_prefab; //바위 속에 있을 아이템

    // [SerializeField]
    // private int count; //아이템 등장 개수

    [SerializeField]
    private GameObject go_effect_prefabs; //채굴 이팩트

    //깨질 때 효과음(임시로 설정한 부분으로 다른 영상에 좀 더 자연스러운 효과음 만들 수 있음)
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip effect_sound1;
    [SerializeField]
    private AudioClip effect_sound2;

    public void Mining() //채굴
    {
        audioSource.clip = effect_sound1;
        audioSource.Play(); //오디오 실행
        var clone = Instantiate(go_effect_prefabs, col.bounds.center, Quaternion.identity); //채굴시 바위가 조금씩 깨지는 효과
        //col.bounds.center : 구체 컬라이더 중심(x,y,z가 알아서 들어감), Quaternion.identity : 회전값(기본값으로 회전하지 않음)
        Destroy(clone, destroyTime); //약간 대기 후에 효과 파괴

        hp--;
        if(hp <= 0)
        {
            Destruction();
        }
    }

    public void Destruction() { //바위 파괴
        audioSource.clip = effect_sound2;
        audioSource.Play(); //오디오 실행

        col.enabled = false; //콜라이더 비활성화

        //채굴되면서 아이템이 생성된다! 이 코드를 여러개 작성 시 그 개수만큼 아이템이 나온다(우리는 1개로 할 듯 하다.)
        Instantiate(go_rock_item_prefab, go_rock.transform.position, Quaternion.identity);

        //여러 개 할 경우 아래의 for문을 사용한다
        //for(int i=0; i <count; ++i)
       // {
       //     Instantiate(go_rock_item_prefab, go_rock.transform.position, Quaternion.identity);
       // }

        Destroy(go_rock); //일반 바위 제거

        go_debris.SetActive(true); //깨진 바위 활성화
        Destroy(go_debris, destroyTime); //destoryTime 만큼 일정 시간 유예를 준 뒤 삭제됨
    }
}
