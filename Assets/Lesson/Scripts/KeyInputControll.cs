using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputControll : MonoBehaviour
{
    private readonly float inputSpeedMove = 5.0f;
    private readonly float inputSpeedRotate = 3;

    void Start()
    {
        
    }

    void Update()
    {
        InputRotate();
        InputRotateMove();
        InputIdentity();
    }

    public void InputRotate()
    {
        float axisY = Input.GetAxis("Horizontal");
        axisY = axisY * inputSpeedRotate * Time.deltaTime;
        this.transform.Rotate(new Vector3(0, axisY, 0));
    }

    public void InputRotateMove()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rotate = rotate * inputSpeedRotate * Time.deltaTime;
        move = move * inputSpeedMove * Time.deltaTime;

        this.transform.Rotate(Vector3.up * rotate);
        this.transform.Translate(Vector3.forward * move);
    }

    void InputIdentity()
    {
        if(Input.GetMouseButton(1))
        {
            this.transform.localRotation = Quaternion.identity;
        }
    }
}

/*
과제 1. 트랜스폼 활용

- 만든 모형에 트랜스폼을 적용한다.

1. 일자형 트랙을 구축하고 트랙의 양끝에서 자동차 2대가 마주보고 달려온다.
 ㄴ 두 객체가 충돌했을 때 튕겨 나가거나 밀리게 만드는 물리 법칙을 적용한다.
 ㄴ 자동차는 움직일 때 바퀴는 회전을 해야 한다.

2. 헬기는 직접 조종이 가능해야 하고 움직일 때는 프로펠러가 회전을 하며 계속 움직여야 한다.

3. 탱크도 직접 조종을 할 수 있으며 상부와 하부를 각각 따로 회전 시킨다. (모빌: 바퀴 회전)
 ㄴ 포션 부분과 자체 부분은 실제 탱크처럼 360도 회전에 신경쓸 것
 ㄴ 포신은 조준이 가능해야 한다.

4. 만든 모형 집 주변을 지키는 가드 (도형)의 패턴을 3종 만들 것


 */
