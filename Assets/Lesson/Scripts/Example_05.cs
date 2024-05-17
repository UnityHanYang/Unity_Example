//#define EXAMPLE_TYPE_METHOD
//#define EXAMPLE_TYPE_CLASS
#define EXAMPLE_TYPE_PROPERTY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 클래스 / 메서드 / 프로퍼티
/*

▶ C# 언어 클래스

- C# 클래스는 참조 타입이다.
    ㄴ 객체의 완전한 복사가 수행되기 위해서는 반드시 깊은 복사에 해당하는 로직을 구현해야 한다.

- C# 클래스는 대표 생성자를 정의할 수 있다.
    ㄴ 대표 생성자를 통해 객체의 초기화 로직을 통일화 시키는 것이 가능하다.

- C# 클래는 중첩 클래스를 지원한다.
    ㄴ C#의 중첩 클래스는 C++과는 달리 자신을 포함하는 외부 클래스의 private 영역 안에 접근하는 것이 가능하다.

- C# 클래스는 소멸자를 구현하지 않는 것을 원칙으로 한다.
     ㄴ 구현은 가능하지만 구현 시 GC의 메모리 관리를 전혀 받을 수 없다.

- C# 클래스는 부모 클래스를 의미하는 키워드를 지원한다.
    ㄴ Base - Derived 클래스가 계승된다.

- C# 클래스는 Sealed 키워드를 통해 상속 여부를 결정할 수 있다.

- C# 클래스는 Partial 키워드를 통해 클래스 분할을 지원한다.
    ㄴ 같은 이름의 클래스를 5개 만들어두고 앞에 Partial을 붙이면 하나의 클래스로 인식됨
    ㄴ Ex) 플레이어의 스킬, 플레이어 아이템.. 이런걸 클래스로 나눌 수 있음.
    ㄴ 파편화 시킬 수 있다.

- C# 클래스는 단일 상속만을 지원한다.
    ㄴ 단, 인터페이스에 한해서 다중 상속을 지원한다.



▶ C# 메서드

- C#의 메서드는 기본적으로 값에 의한 호출이다.
    ㄴ Call By Value

- C# 언어 메서드는 ref 또는 out 이라는 키워드를 통해서 참조에 의한 호출을 하는 것이 가능하다.
    ㄴ Call By Reference

- C# 메서드는 params 키워드를 통해서 가변 길이 매개변수를 처리할 수 있다.
    ㄴ 이거는 C/C++ .... 과 비슷한 역할을 한다. (가변 인자)
    ㄴ printf가 가변 인자 함수임.

- C# 메서드는 호출 시 값이 넘겨질 매개 변수의 이름을 직접 명시하는 것이 가능하다.
    ㄴ 이러한 기능을 네임드 매개변수라고 한다.
    ㄴ 매개변수를 넘겨줄 때 타입의 캐스팅이 가능하다(치환이 가능하다)

- C# 메서드는 자식 클래스에서 재정의하기 위해서는 virtual 키워드를 반드시 명시해줘야 한다.
    ㄴ 또한 자식 클래스에서는 override 키워드를 통해서 부모 클래스의 맴버 함수를 재정의 하고 있다는 것을
       명시해 줘야 한다. C++과 다르게 override 키워드를 명시하지 않으면 컴파일 에러

※ 부모 클래스의 메서드를 오버라이드 하지 않고 동일한 이름의 새로운 메서드를 자식 클래스에서 정의하기 위해서는..
    ㄴ new

- C# 언어의 메서드 또한 sealed 키워드를 통해서 자식 클래스에서 맴버 함수를 오버라이드 하는 것을 막을 수 있다.


  ref 키워드와 out 키워드

- out 키워드는 의미적으로 출력을 한다는 뜻
ㄴ 로직을 작성할 때 발생할 수 있는 초기화 실수를 컴파일러 단계에서 예방이 가능하다.

- ref 키워드는 반대로 변수의 초기화 유무를 보장해 주지 않는다.
ㄴ 참조 오류를 막아주는 키워드

- C# 같은 경우에는 기본적으로 초기화 되지 않은 지역 변수는 사용할 수 없다.
ㄴ 초기화 되지 않은 변수를 사용할 때 컴파일 에러가 발생한다.

- 위의 특징에 따라 ref 키워드를 이용해서 참조 값을 전달할 경우 반드시 해당 변수는 초기화가 되어 있어야 한다.

- 반면에 out 키워드를 이용할 경우 해당 키워드는 참조 값을 전달 받은 메서드에서 반드시 값이 초기화 된다는 보장을 받을 수 있기 때문에
초기화 되지 않는 변수의 참조 값을 전달하는 것도 가능하다.

▶ 프로퍼티

- 객체의 속해 있는 필드에 안전하게 접근 / 제어하기 위한 접근자 함수를 뜻한다. (역할을 한다.)
    ㄴ Get / Set

- 기존에 지니고 있던 Getter / Setter 함수를 좀 더 편리하게 이용하기 등장한 문법
    ㄴ 프로터리를 사용하게 되면 코드를 안전하게 관리 할 수 있으며 + 편리성에 대한 이점 또한 얻을 수 있다.

- C# 언어 프로퍼티의 특징
    ㄴ c#스크립트의 목적지는 인스펙터 창이다.

- C# 언어는 프로퍼티를 통해서 간단하게 접근자 함수를 만드는 것이 가능하다.
    ㄴ 단, 일반적으로 프로퍼티는 맴버 변수와 별개이기 때문에 프로퍼티 안에서 데이터를 조작하기 위한
       맴버 변수가 필요하다.

- 또한 C# 언어에서는 프로퍼티를 사용할 때 내부 구현이 단순할 경우 이를 자동적으로 정의해주는 오토 프로퍼티
기능을 제공한다. 오토 프로퍼티를 사용하면 프로퍼티 로직을 단순하게 할 수 있으며 해당 프로퍼티를 통해
제어할 변수를 별도로 만들지 않아도 된다.

- C# 언어는 프로퍼티를 이용해서 일회성 데이터를 생성하는 것이 가능
    ㄴ 이를 무명 타입 데이터라고 한다.
    ㄴ 무명 데이터는 기본적으로 데이터의 이름이 존재하지 않기 때문에 반드시 var를 통해서 할당을 해야 한다.

- 프로퍼티를 사용해서 클래스를 초기화 하는 것도 가능하며 이는 구조체여도 동일하게 적용이 된다.

- 마지막으로 C#의 프로퍼티는 virtual + override 키워드를 통해서 재정의 캐머니즘을 구현할 수 있다.

 
 */
#endregion

public class Example_05 : MonoBehaviour
{
    private int m_nValue = 100;
    public void Awake()
    {
#if EXAMPLE_TYPE_CLASS
        var DerivedA = new CDerived("Hellfire", this);
        var DerivedB = new CDerived(10, 3.14f, "Hello", this);

        DerivedA.ShowInfo(); // 2번찍힘(부모, 자식)
        // 0, 0
        // Hellofire, 100


        DerivedB.ShowInfo(); // 2번찍힘(부모, 자식)
        // 10, 3.14f
        // Hello, 100

#elif EXAMPLE_TYPE_METHOD

        int nLhs = 10;
        int nRhs = 20;

        // debug: 10, 20
        SwapByValue(nLhs, nRhs);
        Debug.LogFormat("Lhs: {0}, Rhs: {1}", nLhs, nRhs);

        // debug: 20, 10
        SwapByReference(ref nLhs, ref nRhs);
        Debug.LogFormat("Lhs: {0}, Rhs: {1}", nLhs, nRhs);

        int nValueA;
        int nValueB;

        this.InitValue(out nValueA, out nValueB);

        // debug: 10, 20
        Debug.LogFormat("nValueA: {0}, nValueB: {1}", nValueA, nValueB);


        CBase oBase = new CLeaf();

        // 3개 다 호출 됨
        // base부터 호출이 되는데, 왜 base부터 호출이 되는지 override 공부
        oBase.ShowInfo();


        int nSumValueA = this.GetSumValue(1, 2, 3, 4, 5, 1.0f, 2.0f, 3.0f, 4.0f);
        int nSumValueB = this.GetSumValue(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        Debug.LogFormat("nSumValueA: {0}, nSumValueB: {1}", nSumValueA, nSumValueB);


#else
        CWidget widgetA = new CWidget();
        widgetA.Value = 10;
        widgetA.String = "Hell Fire";
        widgetA.SetString("Help, Me");


        CWidget widgeB = new CWidget()
        {
            Value = 20,
            String = "Help"
        };
        // 두개의 객체 변수 초기화는 차이가 있다.
        // 자동 inline을 해주는지 안 해주는지 차이
        // ㄴ 하나는 스택을 지나치고, 하나는 스택에 들어갔다 나온다.
        // 둘의 차이점 찾기!!!!!!!!!!!!!!!!!!!



        string oString = "";
        var oStringBuilder = new System.Text.StringBuilder();


        /*
         String VS StringBuilder

        String: 읽기가 많은 경우에 적합하다.

        StringBuilder: 객체의 참조 값을 힙에서 관리한다. (추가, 삽입, 삭제)
            ㄴ 새로운 객체를 만들지 않고 문자열을 수정하고 싶을 때 사용한다.

        EX)
        - 기존 + 연산자를 통해 문자열 연결을 하고 싶다.
         ㄴ 이렇게 썼을 때 엄청 매우매우 느리다.
            ㄴ 반복문이 들어가기 때문 + 다른 메모리의 값을 복사하기 때문
        
         */

        for (int i = 0; i < 100; i++)
        {
            oStringBuilder.Append((i + 1).ToString());
        }
        oString = oStringBuilder.ToString();

        // 10, Hell Fire
        Debug.LogFormat("위젯 정보: {0}, {1}, {2}", widgetA.Value, widgetA.String, widgetA.GetString());

        // 20, Help
        Debug.LogFormat("위젯 정보: {0}, {1}, {2}", widgeB.Value, widgeB.String, widgeB.GetString());



        // 무명: 이름이 없는 형식
        // ㄴ 무명 형식은 선언과 동시에 인스턴스를 할당한다.
        // ㄴ 무명 형식은 만들고 나서 사용하지 않을 때 유용하나 무명 형식의 프로퍼티에 할당된 값은
        //    변경이 불가능 하다.
        // ㄴ 한번 생성된 인스턴스는 읽기만 가능하다.
        var oAnonymousData = new
        {
            Value = 10,
            String = "Help"
        };
        // 지속적으로 관리를 안 하겠다
        // 동적할당을 하면 강제적으로 GC이 호출된다. -> GC한테 처리를 맡기겠다.
        // 일회성 데이터에 써준다.

        Debug.LogFormat("Data 정보: {0}, {1}", oAnonymousData.Value, oAnonymousData.String);

#endif
    }

#if EXAMPLE_TYPE_CLASS

    /*
     얕은 복사 / 깊은 복사

    - C# 클래스는 결국 참조 형식
    ㄴ 스택 영역에 있는 참조가 힙 영역에 할당된 객체의 메모리를 가리킨다.
    
    클래스를 값으로 할지 참조로 할지
    ㄴ 힙으로 하면 메모리는 더블이 된다, 반면에 속도 면에서는 우월하다
        ㄴ 스택으로 옮기는 것보다 힙에서 처리하는게 더 빠르기 때문
        ㄴ 스택은 그 반대
     */

    //! 기초 클래스 
    class CBase
    {
        protected int m_nValue = 0;
        protected float m_fValue = 0.0f;

        //! 생성자 / 대표 생성자
        public CBase(int nValue, float fValue)
        {
            m_nValue = nValue;
            m_fValue = fValue;
        }

        public void ShowInfo()
        {
            Debug.LogFormat("정수: {0}, 실수: {1}", m_nValue, m_fValue);
        }
    }

    // C#은 상속할 때 public 생략 가능(public으로만 상속 받기 때문에)
    // ICloneable: C# 표준 (깊은 복사를 수행하기 위한 인터페이스)
    // 인터페이스는 상속이 아니라 따른다라는 개념이 맞음.
    // C#은 클래스 상속을 받으면 생성자를 2번 만들어줘야한다.(부모꺼, 자식꺼)
    class CDerived : CBase, System.ICloneable
    {
        private string m_oString = "";
        private Example_05 m_oExample = null;

        public CDerived(string a_oString, Example_05 a_oExample) : this(0, 0.0f, a_oString, a_oExample)
        {

        }

        public CDerived(int a_nValue, float a_fValue, string a_oString, Example_05 a_oExample) : base(a_nValue, a_fValue)
        {
            m_oString = a_oString;
            m_oExample = a_oExample;
        }

        //!  객체 복사 준비
        public object Clone()
        {
            var oDerived = new CDerived(m_nValue, m_fValue, m_oString, m_oExample);

            return oDerived;
        }

        public new void ShowInfo()
        {
            base.ShowInfo();

            Debug.LogFormat("문자열: {0}, 외부 클래스: {1}", m_oString, m_oExample.m_nValue);
        }
    }


#elif EXAMPLE_TYPE_METHOD
    class CBase
    {
        public virtual void ShowInfo()
        {
            Debug.Log("Base 정보 출력");
        }
    }

    class CDerived : CBase
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Derived 정보 출력");
        }
    }

    class CLeaf : CDerived
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Leaf 정보 출력");
        }
    }


    // params: 메서드에서 배열 형태의 매개변수를 받을 때 사용할 수 있다.
    //  ㄴ params는 모든 변수들을 모아서 배열로 만들어 주는 기능
    // 주의점: params 1차원 배열만 가능하며 메서드의 매개변수 마지막에 위치해야 한다.

    //! 정수의 합을 반환한다.
    private int GetSumValue(params object[] a_oParams)
    {
        int nSumValue = 0;
        float fSumValue = 0.0f;

        CBase oBase = new CDerived();

        /*
        ▶ as / is

        - is 키워드 + as 키워드는 둘 다 데이터 타입으로 형변환이 가능한지 검사하는 역할을 수행한다.

        
         차이점

        - is 키워드는 값 형식 참조 형식에 모두 사용할 수 있으며 결과는 논리형으로 반환이 된다.

        - 반면 as 키워드는 참조 형식에만 사용하는 것이 가능하며 결과는 null 또는 해당 타입의 참조 값으로 변환이 된다.
        ㄴ 이러한 특성 때문에 as 키워드는 객체의 안전한 다운 캐스팅을 하는 것을 가능하게 한다.
        
        as를 클래스 타입과 같이 쓰면 업캐스팅, 다운 캐스팅이 가능한지 검사한다.

         */

        CDerived oDerived = oBase as CDerived;

        if (oDerived != null)
        {
            Debug.Log("다운 캐스팅에 성공");
        }

        for (int i = 0; i < a_oParams.Length; i++)
        {
            if (a_oParams[i] is int)
            {
                nSumValue += (int)a_oParams[i];
            }
            else
            {
                fSumValue += (float)a_oParams[i];
            }
        }

        return nSumValue;
    }

    private void InitValue(out int a_nValueA, out int a_nValueB)
    {
        a_nValueA = 10;
        a_nValueB = 20;
        // 값이 초기화가 안 돼있으면, 컴파일 에러를 낸다.
    }

    // Call By Value
    private void SwapByValue(int a_nLhs, int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;

    }

    // Call By Reference
    private void SwapByReference(ref int a_nLhs, ref int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }
#else

    class CWidget
    {
        private int m_nValue = 0;
        private string m_oString = "";

        public int Value
        {

            get
            {
                return m_nValue;
            }

            set
            {
                // value: 전달 받은 인자값을 의미한다.
                m_nValue = value;
            }
        }

        // 오토 프로퍼티
        // ㄴ 코드를 간결하게 해주며 접근자에 조건이 없는 경우 사용을 할 수 있다.
        // ㄴ 값 변경이 안 되도록 private 지정자를 추가하거나 초기값이 필요한 경우 초기값까지 할당 가능
        public int CNumber
        {
            get; private set;
        } = 100;
        // const보다 유동적이고 자율성이 좋다.
        // ex) 5개의 객체가 Cnumber를 참조하고 있을 때 4개의 객체는 set을 막아버리고 나머지 객체는 private를 풀어줄 수 있다.

        public string String
        {
            get; set;
        }

        public int GetValue()
        {
            return m_nValue;
        }

        public string GetString()
        {
            return m_oString;
        }

        public void SetValue(int nValue)
        {
            m_nValue = nValue;
        }

        public void SetString(string str)
        {
            m_oString = str;
        }
        // 프로퍼티를 묶어놓은 구조체, 클래스가 필요하다.
        // 프로퍼티 혼자만 쓰지 않기

    }
#endif
}
