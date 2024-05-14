using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오브젝트 풀링
/*
▶ 오브젝트 풀링

- 유니티 최적화를 언급할 때 나오는 사골

  동작 방식

- 오브젝트를 미리 저장할 오브젝트 풀을 만들고 이곳에 빌려줄 오브젝트를 생성한다.
ㄴ 동적 / 정적

- 생성된 오브젝트는 오브젝트 풀에서 보관하고 외부에서 이 오브젝트 콜 요청이 들어오면 오브젝트 풀에서
빌려주는 개념이라고 이해하면 좋다. (빌려준 오브젝트가 사용이 끝나면 다시 오브젝트 풀에 반납)

- 예외적으로 외부에서 오브젝트 풀 안에 있는 모든 오브젝트를 다 빌려쓰고 있으면 오브젝트 풀 입장에서는
더 이상 대여해 줄 수 있는 오브젝트가 없으므로 그때서야 새로운 오브젝트를 생성한다.

- 이 때 생성된 오브젝트는 사용이 끝나면 돌려 받지만 파괴되지 않고 오브젝트 풀 안에 보관이 된다.

- 이러한 사용 루틴으로 인해 오브젝트 풀링은 단순하게 오브젝트를 활성화 / 비활성화 하는 개념

- 오브젝트 풀링은 크게 단일 / 다중으로 나눠서 관리할 수 있다.


  장점

- 가바지 컬렉션을 사용하지 않는다
Destroy 사용을 안함 -> 가비지 컬렉션이 나올 일이 없다


  단점

- 오브젝트를 새로 생성할 때 new를 몇 백번씩 호출 하고, Destroy가 몇 백번 호출 됨 -> 퍼포먼스 저하

 */
#endregion

#region 인스팩터 속성
/*

▶ 속성

- 스크립트에서 클래스와 속성, 또는 함수, 또는 메서드와 변수 위에 추가하여 속성에 기반한 동작을 하게 할 때 사용하는 키워드

◆ SerializeField
ㄴ 직렬화 수행 (에디터 접근 범위 설정)
직렬화, 역직렬화가 있음.
ㄴ public이 아닌 비공개 맴버가 유니티가 직렬화 하도록 강제하는 명렁어
ㄴ 인스팩터에 노출시키는 용도

- 마샬링
ㄴ 데이터 구조 / 오브젝트 상태등을 유니티 에디터가 저장하고 나중에 제공할 수 있는 포맷으로 자동으로 변환하는
포르세스

※ 유니티에서는 저장 및 로딩 / 인스팩터 / 인스턴스 / 프리팹과 같은 일부 내장 기능에 한해 직렬화가 사용이 된다.

 1. Serializable
ㄴ 유니티는 기본적으로 인스팩터에는 클래스나 구조체를 표시할 수 없다.
ㄴ 이러한 구조체나 클래스를 인스팩터로 노출시키는 속성

 2. SerializeField
ㄴ private 필드를 인스팩터 창에 노출
ㄴ 다른 클래스에서 참조하진 않지만 변수를 노출 시키고 싶을 때 사용 (참고)

★
 3. HideInInspector
ㄴ public 필드를 인스팩터 창에 노출시키진 않지만 수정할 수 있음.

★
 4. RequireComponent (typeof (Component)
ㄴ 최대한 많이 쓸 것
ㄴ 스크립트가 알아서 붙게하는 놈
ex) 머리 하나로 팔 2개, 몸을 붙이게 할 수 있다.

 5. Header ("string")
ㄴ 타이틀
ㄴ 규모가 커질수록 정리는 필수

 6. Multiline (int)
ㄴ 장문
ㄴ 인스팩터 창에서 문자열을 쓸 때 너무 길어지면 글자가 짤림
ㄴ 그 때 창을 길게 해줘서 다 볼 수 있게
ㄴ 다른 개발자에게 경고할 때 많이 씀

 7. Range (int, int) // Range (float, float) 
ㄴ 슬라이드 바를 지원함
ㄴ 스크립트의 최대 값 이상을 집어넣으면 강제로 최대값으로 맞춰줌.
ㄴ UI에서 많이 씀

 8. Space (int / float)
ㄴ 여백
ㄴ 인스팩터 정리용
ㄴ 배열에서 많이 씀.
ㄴ 인스팩터에서 배열의 인덱스 간격을 벌려준다.

 9. Tooltip ("string")
ㄴ 인스팩터 정리용
ㄴ 기능에 마우스를 올려두면 해당 기능의 설명을 보여준다.


최대한 인스팩터 창에서 변수, 자료구조를 확인할 수 있게 정리해둬야한다.
워스트: 스크립트를 열어서 확인하는 것

 */
#endregion

public class ObjecPolling : MonoBehaviour
{
    int pointer;

    // List<T> value = new List<T>();
    // ㄴ 가변 배열 컨테이너(추가 및 삭제가 용이하다.)
    // 박싱, 언박싱은 일반적으로 안 좋다. -> 가비지 컬렉션과 연관이 있음.
    // ㄴ 같은 데이터 타입만 저장 가능하니 이는 곧 박싱과 언박싱을 수행하지 않는다는 얘기
    List<GameObject> pool;

    [SerializeField] private GameObject pooledObject; // 내부에서는 사용이 되나, 인스팩터에서 보일 뿐, 깡통임 -> 인스팩터에서 수정을 할 수가 없음.
    // 외부에서 참조가 안 됨.

    void Start()
    {
        // Range(min, max): 랜덤값 설정 -> 시작값은 포함 / 마지막은 max - 1까지 포함
        int size = Random.Range(10, 15);

        pointer = 0;
        pool = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(pooledObject, Vector3.zero, pooledObject.transform.rotation);
            obj.SetActive(false);
            obj.transform.parent = transform;
            pool.Add(obj);
        }
    }

    public void SpawnObj()
    {
        // 스마트 포인터 공부하기
        // 스마트포인터의 동작구조를 인지해서 스마트포인터가 활용된 구조를 쓸 수 있다는 방식으로 가야한다.

        if(pointer != pool.Count)
        {
            pool[pointer].SetActive(true);
            pointer++;
        }
        else
        {
            pointer = 0;
            pool[pointer].SetActive(true);
            pointer++;
        }
    }
}
