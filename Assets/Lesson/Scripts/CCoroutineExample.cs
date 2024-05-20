using System.Collections;
using UnityEngine;

#region 코루틴
/*

▶ 코루틴 (Coroutine)

- Co + routine
ㄴ 협력하는 루틴이다.

- 일정 시간 간격을 두고 함수를 호출할 때 사용한다.
ㄴ 코루틴으은 프레임과 상관없이 별도의 서브 루틴에서 원하는 작업을 원하는 시간 만큼 수행하는 것이
가능하다.

- 코루틴이 여러 개의 서브 루틴을 생성한다고 해서 스레드와 같다고 생각을 하는데 코루틴은 "비동기"
스레드는 "동기"

가벼운 것을 선처리해주고 그 다음 무거운 것을 처리한다 -> 동기
하나의 작업을 할 때 다른 작업도 할 수 있다 -> 비동기

- 스레드와 코루틴의 가장 큰 차이점
ㄴ 스레드의 경우 lock을 걸어 우선 동기화를 시켜줘야 하지만 반면에 코루틴은 lock을 걸지 않는다.

유니티는 싱글 스레드다.
ㄴ 할 수 있는 일이 1가지

n개 이상의 프로세스는 각각 다른 기능을 가져야한다.
obj파일로 병합하는 기능은 첫번

코어: 컴퓨터가 쓸 수 있는 스레드 수
ㄴ 많으면 많을 수록 게임이 원활하게 돌아간다.
    ㄴ 스레드가 많다는 건 

컨테스팅 스위치: a한번 b 한번, 각각 순서에 맞춰 한번씩 계속 실행되는 것.
ㄴ cpu의 문제점: 컨테스팅 스위치를 할 때 속도가 너무 빨라서 a, b 각각 한번씩 실행되는게 아닌 aa, bb 이런식으로 연속으로 실행되는 경우가 있음
-> 이 문제를 해결하기 위해 lock을 걸어줌.

크리티컬 섹션이라는 영역으로 바뀐다.


▶ 코루틴을 사용해야 하는 이유?

- 코루틴은 항상 실행되는 것이 아니라 특정 상황에서 호출하고 반복 작업을 하는게 안정적으로 가능하다.

- 이러한 점에서 매 프레임 실행되는 Update 보다 특정 상황에서 아주 강력 + 효율적이다.
ㄴ 신입 기준 /


※ 포폴에서의 코루틴...

- 남발 ?

- 코루틴이 들어가는 상황은 매번 뭔가를 체크해야 할 때?

- 조건문을 줄이고 싶을 때?

- 함수 + 메서드의 양을 줄이고 싶을 때?


  결론

- 대기 시간보다 실행 시간이 많은 경우에는 코루틴은 좋은 선택이 아니다.

- 특정 조건에 의해 읠시적으로 실행되는 경우나 시간의 호름대로 실행할 때 코루틴을 사용하면 아주 좋다.


  함수 원형

IEnumerator Coroutine()
{
    yield return type;
}


▶ Ienumerable

- C++ 반복자와 비슷하게 사용하기 위한 C#의 반복자 패턴

- 컬렉션 중 하나이며 반복문에서 객체를 한 개씩 넘겨주는 역할을 수행한다.
ㄴ C# -> 컨테이너 -> foreach


가산점 질문

  STL or 유사기능
C++                           C#
Vector / List           ArrayList / List
Map                    Dictionary / Hashtable
Pair                     KeyValuePair


▶ IEnumerator?

- 열거자 (컬렉션 중 하나이며 포인터와 비슷한 역할을 한다.)

- IEnumerator는 기본적으로 Eumerator가 가지고 있어야 할 메서드들을 들고 있는 인터페이스

Reset을 하면 인덱스가 0이 아니고 -1임.

커서위치를 알 수 없기 때문에
movenext를 실행시키면 -1에서 0이 되기 때문에 -1로 설정함.

커서의 위치->스테이트
인스턴스가 생성되고 메모리의 맨 첫번째에 커서위치가 지정된다.

yield를 만나면 스테이트가 1씩 증가한다.
ㄴ yield2에서 yield3으로 갈 때 외부의 요인으로 스테이트를 처음으로 돌아갈 때 Reset이 발생한거임.


▶ 고민을 해봅시다.

- IEnumerator는 n+1 / n+2 / n+3 이라는 식으로 데이터를 넘겨준다.

- 이 때 중요한 건 넘겨주는 쪽이 몇번째 데이터를 넘겨줬는지 기억을 하고 있어야 한다.

EX)

IEnumerable -> 다음 데이터 내놔.

    
                다음 데이터 내놔.
                다음 데이터 내놔.
IEnumerable ->  다음 데이터 내놔.
                다음 데이터 내놔.
                다음 데이터 내놔.
                다음 데이터 내놔.


                IEnumerator(n+1)         ->         다음 데이터 내놔.
                IEnumerator(n+1)         ->         다음 데이터 내놔.
IEnumerable ->  IEnumerator(n+1)         ->         다음 데이터 내놔.
                IEnumerator(n+1)         ->         다음 데이터 내놔.
                IEnumerator(n+1)         ->         다음 데이터 내놔.
                IEnumerator(n+1)         ->         다음 데이터 내놔.

IEnumerator-> 반복만 시켜준다. 안의 데이터를 처리하는 것은 개발자가 해야함.


배열의 각각의 원소들은 다른 원소들을 모른다.
ㄴ 

배열의 인덱스의 값을 5로 바꾸고 그 인덱스를 출력하면 값이 5가 나옴.
ㄴ 메모리 상에선 4, 5, 6이 나와야 한다.


배열은 다음꺼만 기억하고 이전꺼는 기억하지 않는다.
받아가는 객체에서는 n-1이 나올 때 까지 계속 Request가 만날 때까지 계속 다음 데이터를 받음.


면접 질문
코루틴 관련 질문

- 코루틴 써봤냐
- 코루틴에 대해 설명해봐라
- 코루틴 동작 방식 설명해봐
- 포폴에서 쓴 코루틴 로직 설명해봐라
- 코루틴 왜 썼냐


▶ 코루틴 속성 값

- yield return은 실행을 끝내고 다음 프레임에서 실행을 재개할 시점


IEnumerator Coroutine()
{
    yield return new WaitForSeconds
    
    yield return null
    ㄴ 다음 업데이트까지 대기 (프레임)

    yield return new WaitForFixedUpdate
    ㄴ 다음 물리 업데이트까지 대기

특정 조건이 trigger될 때까지 무한 stop하겠다.
ㄴ 애니메이션과 같이 많이 씀

    yield return new WaitForEndofFrame
    ㄴ 랜더링이 끝날 때까지 대기

화면 변경할 때 많이 씀
ㄴ 다음 씬에 들어가는 것을 막아줄 수 있다.

    yield return StartCoroutine(String)
    ㄴ 안에 들어온 다른 코루틴이 끝날 때까지 대기

    yield return WWW(String)
    ㄴ 웹 통신 작업이 끝날 때까지 대기

    yield return new AsyncOperation
    ㄴ 비동기 작업이 끝날 때까지 대기 (씬 로딩)

    yield break;
    ㄴ 실행이 완료되기 이전에 임의로 코루틴 종료


※ yield return이 중첩이 되면..

- 코루틴이 먼저 호출되고 다시 한번 while문이 실행되면 가장 마지막에 있는 리턴문이 일어났던 위치의 다음 줄 부터
실행을 재개하는 구조를 가지고 있다.

- 실행이 재개되면 } or yield 문을 만나기 전까지 반복해서 코드를 읽어들인다.


}

 */
#endregion

public class CCoroutineExample : MonoBehaviour
{
    // 1. this를 전재한 방식
    // 나만 쓰겠다.
    //void Update()
    //{
    //    CoroutineSample();
    //}

    //private void CoroutineSample()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine("MoveToCoroutine");
    //    }
    //}

    //IEnumerator MoveToCoroutine()
    //{
    //    float delayTime = 1.0f;

    //    yield return new WaitForSeconds(delayTime);

    //    this.transform.Translate(0, 0, 1.0f);
    //}

    // 2. 참조 전재
    private IEnumerator coroutine;

    // Invoke: 메서드를 일정 시간 만큼 지연할 때 사용한다.
    // Repeating / Cancel / Cancel(String)

    private float Delay = 2.0f;

    // Start에 코루틴이 물리는 경우에는 기본적으로 Invoke 요놈과 고민을 해봐야 한다.
    // 코루틴 단점: 메모리 사용량
    void Start()
    {
        coroutine = PrintCount(2.0f);
        StartCoroutine(coroutine);

        InvokeRepeating("InvokeSample", 5f, Delay);
    }

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            // StopCoroutine(IEnumerator) / StopCoroutine(String MethodName) / StopAllCoroutine()
            StopCoroutine(coroutine);
            // 해당 객체의 Enumerator만 빼줌 -> 메모리 상에서 코루틴이 빠지지 않음.
            StopCoroutine("PrintCount");
            // Enumerable 자체가 빠지기 때문에 메모리 상에서 코루틴이 빠짐.

            Debug.Log("정지: " + Time.time);

            CancelInvoke();

        }
    }

    public IEnumerator PrintCount(float waittime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waittime);
            Debug.Log("PrintCount: " + Time.time);
        }
    }
}




/*
과제1. 프로젝트에 대한 기획서 작성

- 제출: 다음 주 월요일 수업전까지

--------

- 메일로 제출
- 양식을 꼭 지킨다.

- 메일 제목(양식): VR 7기_게임플랫폼 응용 프로그래밍_이름

- 첨부 파일:
ㄴ VR 7기_게임플랫폼 응용 프로그래밍_이름.zip
    ㄴ 1. 프로젝트 2. 실행파일 캡쳐
                        ㄴ 01 /  02 / 03

ㄴ VR 7기_게임명_이름.ppt (기획서)

- 메일 내용:
ㄴ 특이사항 기입

 
  능력 단위 평가 지시

- 작업 지시서 기반 프로젝트를 완성하고 제출하시오.

- 오브젝트 풀 무조건 쓰기

 
 */
