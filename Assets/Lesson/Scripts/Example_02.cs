// System: 숫자나 텍스트 같은 데이터를 다룰 수 있는 기본적인 데이터 처리 클래스를 비롯하여 C# 코드가
// 기본적으로 필요로 하는 클래스를 담고 있는 namespace
// Collections: 간단하게 말하자면 자료구조 -> 데이터 모음
// ㄴ 배열 / 스택 / 큐 / 해쉬 테이블 등이 C#에서는 컬렉션이라는 이름으로 제공이 된다.
using System.Collections;

// 일관화된 컬렉션을 사용하겠다. (추가한다)
// C++에서 STL (list, que, stack)
// 기본 컬렉션은 타입이 정해져 있지 않기 때문에 형반환이 번번하게 발생하고 있는 곧 성능저하로 이어진다.
// ㄴ 이러한 문제점을 보완한게 일반화 컬렉션
using System.Collections.Generic;
using UnityEngine;

#region 유니티 스크립트
/*
▶ 스크립트 (Script)

- 유니티 엔진에서 커스텀하게 동작하는 별도의 로직을 작성하기 위해 존재하는 컴포넌트
ㄴ 스크립트를 통해서 엔진에서 제공되지 않는 기능을 구현하는 것이 가능하다.

- 예전에는 자바 스크립트 / Boo 라는 언어를 지원했지만 현재는 C#을 기본적으로 채택하고 있다.

- 스크립트는 전문적인 프로그래밍 언어가 아니라 일종의 간이 언어로 작성된 짧은 명령어들로 보는게 맞다.

- C / C++ / C#에 비해 제한된 능력을 지니고 있지만 프로그램을 쉽고 빠르게 작성할 수 있으며 언어의 제한적인
기능만 사용하므로 초심자들이 배우기가 쉽다는 장점이 존재한다.

- 우리는 스크립트를 게임의 목적에 따라 행위를 설정할 때 사용하며 결국 유니티로 게임을 잘 만들기 위해서는
스크립트를 잘 활용할 줄 알아야 한다. <- 회사에서 우리를 뽑는 이유

▷ 유니티 스크립트의 특징 (C# 언어)

- 스크립트가 게임 객체에 컴포넌트로 추가되기 위해서는 반드시 MonoBehaviour를 직/간접적으로 상속해야 한다.

- 유니티 스크립트는 StartCoroutine 메서드를 이용해서 협력적으로 동작하는 루틴을 작성하는 것이 가능하다.
ㄴ 콜틴 기능을 제공한다는 얘기

- 또한 에디터 스크립트를 제공하기 때문에 해당 기능을 이용하면 별도의 작업 환경을 구축하는 것 또한 가능

- 유니티 스크립트는 메시지 방식으로 구동하기 때문에 SendMessage 함수를 통해서 특정 게임 객체가 지니고 있는
스크립트의 메서드를 호출하는 것이 가능한 구조

- 이는 BoardCastMessage를 발생시킬 수 있다는 얘기고 특정 게임 객체의 자식 객체를 포함해서 메시지를 전파하는 것이
가능하다.

▷ Coroutine(협력하는 루틴)
n개 이상의 프로세스를 실행시킬 수 있는 루틴
n개 이상의 리턴값이 있는 함수

메모리 낭비를 방지하기 위한 함수

유니티는 싱글 스레드를 권장하기 때문에 코루틴을 지원한다


▷ SendMessage(합법적 goto문(아무런 문제가 없다))
ㄴ 상속관계, 접근지시자를 싹 다 무시한다.


▷ BoardCastMessage
ㄴ 다른 스크립트에 전파한다.
ㄴ 속도를 챙길 수 있다.


▷ 유니티 이벤트

- 스크립트 객체 안에 다른 기능은 특정 이벤트라 부르며 가장 많이 사용되는 이벤트는 아래와 같다.
ㄴ Awake(가장 먼저 실행되는 함수(메서드), 이니셜라이저(생성자))
ㄴ Start
ㄴ Update
ㄴ FixedUpdate(물리연산에 사용되는 업데이트 함수)
ㄴ 코드 외부 함수(스크립트의 상태를 초기화할 때 사용하는 함수)
ㄴ 사용자 정의 함수(메서드)

 */
#endregion
/// <summary>
/// 시작 클래스
/// </summary>
/// <param name="현재 상태">MonoBehaviour를 상속받는 기본 클래스.</param>
public class Example_02 : MonoBehaviour
{
    /*
    MonoBehaviour: 유니티의 중요하며 기본적인 함수들을 지원하고 있다.
    
    MonoBehaviour -> Behaviour -> Component -> Object
    ㄴ 상속 구조

    메서드? (C#) 함수?
        ㄴ 함수: 코드 조각 및 모음 / 독립된 기능
        ㄴ 메서드: 클래스 함수 (클래스 및 객체)

    - 스크립트 컴포넌트에서 다른 객체 또는 자기 자신의 객체에 속해 있는 컴포넌트에 접근하기 위해서는
    일반적으로 gameObject.GetComponent<T> 함수를 이용한다.

    - 또한 자주 사용되는 컴포넌트는 미리 프로퍼티로 정의가 되어 있기 때문에 해당 프로퍼티를 이용하면 좀 더
    편하게 접근하는 것이 가능하다.

     */

    // 인스턴스가 만들어질 때 한 번 실행된다.
    // ㄴ 주로 초기화를 위해 사용되며 한 번만 호출된다.
    // 활성화 되든, 안 되든 반드시 한 번 호출이 된다.
    void Awake()
    {
        // print(): 콘솔 뷰에 다양한 Value 확인 가능
        // ㄴ Debug.Log를 Wrapping 한 클래스
        // Wrapping: 사용하기 쉽게 빼왔다.
        print("Awake Call"); // 실행속도 면에선 유리하다(MonoBehaviour를 상속해야한다.(메모리 낭비가 됨))
    }

    // 함수 안에 들어 있는 명령어는 게임 시작과 동시에 자동으로 실행이 된다.
    // 비활성화가 되면 호출을 안 한다. (스크립트 요소가 활성화 상태여야 한다.)
    void Start()
    {
        print("Start Call");
        Debug.Log(this.gameObject + " 입니다"); // Debug는 클래스이기 때문에 가져오는데 무겁다.
    }
    
    // 해당 영역에 있는 명령어는 게임이 실행되는 동안 매 프레임마다 자동으로 한 번씩 반복 호출
    // 내가 만들 게임에 FPS를 설정하려면 주로 Update에서 처리가 발생한다.
    // ㄴ 불완전 호출
    // 하드웨어의 영향이 크다.
    // 성능이 느린 컴퓨터가 프레임이 낮아 뚝뚝 끊기면 문제가 생긴다 -> 불완전 호출
    void Update()
    {
        print("Update Call");

        /*
        ▶ GetKey 시리즈

        - 유니티에서 지원하는 GetKey(액션 매핑) / GetAxis(축 매핑) 시리즈
        ㄴ 그 중에 GetKey는 KeyCode를 사용하여 입력을 받는다.

        EX)
        GetKey: 특정 키를 누르고 있는 동안 true를 반환하는 Input 함수
        GetButton: 유니티 내부에 정의된 버튼 이름을 사용하겠다.

        ※ 반환 여부에 차이점 또한 존재

        자매품 
        - OnMouse~ 시리즈
        ㄴ 콜라이더가 존재해야 동작 가능

         */

        if (Input.GetKeyDown(KeyCode.Return)) // KeyCode.Return -> 엔터
        {
            Destroy(this.gameObject);
        }

        //if (Input.GetButton(KeyCode.Return)) // KeyCode.Return -> 엔터
        //{
        //    Destroy(this.gameObject);
        //}
    }

    // 카메라
    // 캐릭터가 움직이면 카메라가 그 위치로 움직일 때 사용
    // 카메라가 뒤따라 갈 때 LateUpdate
    void LateUpdate()
    {
        
    }

    // Update의 단점을 개선하기 위해 나온 Update
    // 물리 업데이트
    // 정해진 시간 값에 기반해서 동작한다.
    void FixedUpdate()
    {
        // 기본시간: 0.02 Sec
        // 0.02초 마다 1번씩 실행
    }

    // 이 메서드를 잘 쓰면 bool 사용을 줄일 수 있다.
    void OnDisable()
    {
            
    }

    void OnDestroy()
    {
        // 남발 금지
        // // 단, Prefab을 사용할 때는 예외
    }

    // OnBecameInvisible. OnBecameVisible는 한 클래스에 안에 같이 쓸 수 없다.

    // 오브젝트가 게임 뷰에 나갈 때 처리해주는 메서드
    // 총 게임할 때 총알이 게임 뷰 밖으로 나갈 때 사용
    void OnBecameInvisible()
    {
        // Destroy() 메서드를 쓸 수 있음
    }

    // 오브젝트가 게임 뷰에 나타날 때 처리해주는 메서드(이 메서드는 보통 카메라한테 붙는다.)
    // Ex) 보스방에 들어가서 보스한테 카메라를 비쳐줄 때 사용
    void OnBecameVisible()
    {
        
    }

    // 비어있는 오브젝트 또는 시각적으로 편하게 보기 위해 사용한다.
    // ㄴ OnDrawGizemosSelected -> 선택했을 때만
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));

        //Gizmos.DrawWireSphere(this.transform.position, 1.0f);

        Gizmos.DrawCube(this.transform.position, new Vector3(1, 1, 1));
        Gizmos.DrawWireSphere(this.transform.position, 1.5f);
        
        // 기즈모에서만 작동한다는 건 씬뷰에서만 보인다는 뜻
    }

    // 코루틴
    // 애니메이션 처리할 때 편함
    IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(10.0f);

        yield return new WaitForSeconds(10.0f);

        yield return new WaitForSeconds(10.0f);

        yield return new WaitForSeconds(10.0f);

        yield return new WaitForSeconds(10.0f);
    }
}


/*
과제 1.

만들 게임 3가지 후보를 추려와라.
ㄴ 장르 겹치지 않게
ㄴ 시뮬레이터 게임 빼기
ㄴ 턴제 rpg(강추, 엔진빨을 잘 못 받음)


27일부터 포트폴리오 후(2주)
김한별 교수님께서 유니티 심화를 시작하심
 */
