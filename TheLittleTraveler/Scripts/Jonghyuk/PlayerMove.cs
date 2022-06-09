using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;

    // 캐릭터 컨트롤러 컴포넌트 변수
    CharacterController cc;

    float gravity = -20f;
    // 수직 속력 변수
    float yVelocity = 0;

    // 플레이어 체력
    //public int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        // 메인 카메라를 기준으로 방향을 변경
        dir = Camera.main.transform.TransformDirection(dir);

        transform.position += dir * moveSpeed * Time.deltaTime;

        // 수직속도에 중력 값 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 이동 함수
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }

    // 다른 스크립트에도 접근하기 때문에 public 추가
    //public void DamageAction(int damage)
    //{
        //hp -= damage; // 10 -> 7 -> 4 -> 1 -> -2, 체력이 음수가 되면 바로 0으로
        //if (hp < 0)
        //{
            //hp = 0;
        //}
        //print(hp);
    //}
}
