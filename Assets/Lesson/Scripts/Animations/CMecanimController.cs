using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 유니티 애니매이션
/*

▶ 유니티 애니메이션

- 유니티 애니메이션은 크게 2가지로 나뉜다.
    ㄴ 1. 레거시
    ㄴ 2. 메카님

▶ 레거시

- 레거시는 오브젝트마다 가지고 있는 애니메이션을 외부 툴로 작업을 하고 가져오는 방식이다

- 레거시는 인간형이 아닌 모델에 자주 적용이 되어 있다.
    ㄴ 이유는 레거시 자첵다 이식성이 떨어지고 확장성이 메카킴에 비해 떨어지기 때문


▶ 메카님

- 메카킴은 유니티 버전이 릴리즈되면서 추가된 애니메이션 상태 머신 툴이라고 할 수 있다.

- 레거시 애니메이션이 가지고 있는 단점으로 자연스러운 애니메이션 / 확장성을 해소한 에니메이션 기법이라고 할 수 있다.

  장점

- 이식성과 재생산성이 좋다.

- 인체형 애니메이션 모델의 본 구조만 일치한다면 다른 애니메이션이나 모션 애니메이션을 작용할 수 있다.

- 직관성이 뛰어나다.


  단점

- 스테이트가 많아질 수록 확장성이 떨어지며 상태 전이를 관리하기 위해 매우 복잡해 진다.

- 또한 최초 설계가 까다롭고 수정이 용이하지 못하다.

※ 레거시는 Animation이라는 컴포넌트 사용 / 메카님 Animator를 이용한다.


  애니메이터

- 게임 오브젝트에 장착하는 특별한 유형의 애니메이션 컴포넌트

- 애니메이션 제어를 위한 정보가 들어 있기 때문에 애니메이션을 사용하려면 애니메이터 또한 사용을 해야 한다.


▷ 애니메이션 타입

- 휴머노이드
ㄴ 머리 / 팔 / 다리가 있는 캐릭터는 일반적으로 일간형으로 분류가 되고 인간형 객체들은 리타켓팅을 통해 애니메이션을 공유할 수 있다.
    ㄴ 이게 가능한 이유는 아바타를 공유할 수 있기 때문에

- 제네릭
ㄴ 휴머노이드를 제외한 나머지 오브젝트들이라고 생각하면 좋을 것 같다.
ㄴ 기본적으로 리타켓팅 대상 객체들은 아니지만 애니메이션 구조를 사용하고 싶을 때 사용되는 형태
    ㄴ 확장성이 떨어지지만 연산 속도가 빠르다.

처형 모션에 객체가 바뀐다 -> 레거시로 표현

▶ 유니티 엔진 유한 상태 머신 (Finite State Machine)

- 유한 상태 머신 (FSM)은 상태와 행동에 따라 독립적인 클래스로 제어와 교체가 가능하도록 하는 패턴을 의미한다.

- 유한한 상태를 정의하고 처리하는 구조이며 각 State가 있고 그 State를 전이시키기 위한 조건이 있는데 그것을 표현하는 기법
이라고 할 수 있다.


  FSM 주요 개념

- State
ㄴ 정의된 하나 / 여려 동작을 의미한다.

- Transition
ㄴ 한 상태에서 다른 상태로 전이하는 것을 말한다.

- Event
ㄴ 상태 전이를 위한 조건 / 조건이 만족하면 성태 전이가 발생한다.

- Action
ㄴ 실제 행동이 실행된다.

※ 공통적으로 각 상태 로직은 외부 전이 조건에 따라 변경이 될 수 있다.


  포인트
ㄴ 애니메이션 클립이 적다면 레거시 / 메카님
ㄴ 애니메이션 클립이 많거나 적거나 대상 객체가 휴머노이드라면 무조건 메카님
ㄴ 애니메이션 클립이 적고 제네릭 타입이라면 레거시 / 메카님
    


인간형 -> 메카님
그 외의 모델 -> 제네릭 레거시

애니메이션 실행 시 캐릭터의 노란색 구? 테두리를 다이나믹 본 이라고 한다.

step offset: 계단 기준(0.3이면 0.3의 계단만 올라갈 수 있다)
skin width: 끼임 현상 방지(무시하겠다)
ㄴ 맵에 끼면 자동으로 오브젝트를 위로 올린다.

맵에 껴서 오브젝트를 움직일 수 없는 상태
ㄴ 계속 비비면 돌체를 꺼주고, 오브젝트를 위로 밀어버림
    ㄴ 지터 현상

min mouse distance: 고정
내리막길에서 자동차 바퀴가 못 굴러가게 막아주는 옵션
or
바람의 영향을 받지 않게 할 때 사용

radius: 반지름


Animator
Apply Root Motion: 애니메이션 유니티가 제어할거냐(true) / 자신이 제어할 거냐(false)



Update Mode

- normal이면 코루틴, 업데이트 둘다 쓴다.

- Unscaled Time:자신이 설정한 프레임 단위로 실행하겠다


Culling Mode: 최적화

vertex를 챙기면 연산량이 날뛰지만 시각적으로 리얼해진다.
ㄴ vertex를 안 챙기면 반대



애니메이션 블랜딩
ㄴ 다음 애니메이션과 어떻게 자연스럽게 이어질 것인지 제어해주는 것
 */
#endregion

public class CMecanimController : MonoBehaviour
{
    CharacterController chanController;
    Vector3 direction;

    #region public 변수

    public float runSpeed = 4.0f;
    public float rotationSpeed = 360f;
    #endregion

    Animator animator;
    void Start()
    {
        chanController = this.GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetFloat("ASpeed", chanController.velocity.magnitude);
        ChanControl_Slerp();
    }

    private void ChanControl_Slerp()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // sqrMagnitude: 제곱근
        if (direction.sqrMagnitude > 0.01f)
        {
            //Slerp: 보간 
            // ㄴ 캐릭터가 뒤로 돌면 자연스럽게 도는게 아닌 바로 뒤를 돌기 때문에 보간을 통해 자연스럽게 돌게 해준다.
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            // 시작 점, 도착 점, 보고 있는 방향에서
            // 다이랙션 방향으로 회전을 시켜야한다.

            transform.LookAt(transform.position + forward);
        }
        else
        {
            // 설정 x
        }

        chanController.Move(direction * runSpeed * Time.deltaTime);
    }
}
