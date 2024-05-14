using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Material
/*
▶ Material (재질)

- 재질은 3D모델의 외형을 설정하기 위한 수단

- SurFace에 적용할 수 있는 미리 빌드된 비주얼 이펙트

- 머터리얼은 색상 설정부터 이미지 기반의 반사적 표현에 이르기까지 모든 것을 닫루며 세이더 또한 재질에서 처리되는
경우가 많다.

- 머터리얼은 텍스처, 색상, 거침, 빛, 등의 모든 서피스 디테일을 감싸는 구조를 가지고 있다.

- 또한 스태틱 메시에 텍스쳐를 적용하거나 여러 장의 텍스텨를 포함할 수 있다.


▶ UV
(u가 x, v가 y)
텍스쳐 좌표가 UV좌표가 된다.
uv는 백분율을 가지고 있다.

vertex는 2d의 x,y로 표현된다->dot으로 표현한다

- 축소 시에 적용할 수 있는 다양한 렌더링 속성이 존재한다.
Warp(반복) / Clamp(비반복) / Mirror 
Warp: 다 바르고 남는 빈칸이 있으면 다시 바르겠다.
Clamp: 다 바르고 남는 빈칸이 있어도 다시 바르지 않는다.(남는 빈칸은 색상으로 채운다)
Mirror: 뒤집어서 다시 그리겠다.

데카르트: y가 증가하면 위로가고 y가 감소하면 아래로 내려간다
윈도우: y가 증가하면 아래로 가고 y가 감소하면 위로 간다.


rendering mode: cutout->그물망, Transparent: 유리같이 비쳐지는데 사용
metallic: 금속 정도
Normal map: 굴곡
Height map: 높낮이를 표현할 때 사용
Occlusion: 음영
Detail mask: 텍스쳐를 표현할 때
Emission: color바의 hdr->어두울 땐 더 어둡게, 밝을 땐 더 밝게

Secondary Maps: 4k 8k를 지원함

Tiling == UV
UV Set: UV 채널

 */
#endregion

#region 유니티 충돌체
/*

▶ 유니티 엔진의 충돌체

 특징

- 유니티 엔진은 내부적으로 충돌 판정을 검사할 때 충돌체를 기반으로 연산을 수행
ㄴ 게임 오브젝트가 충돌체가 없으면 충돌 판정 검사가 불가능

-  충돌체의 모양은 실제 랜더링 되는 물체의 모양과 일치하지 않아도 된다.
ㄴ 이는 일부분만 충돌 영역으로 설정하는 것을 허용한다는 뜻

- 유니티 엔진은 복합 충돌체를 지원한다.

- 그리고 대표적으로 사용되는 리지드 바디를 통해 간단한 물리 연산을 지원한다.

  리지드바디

- 유니티는 물리 연산이 필요할 경우 리지드 바디 컴포넌트를 포함시켜야 한다.
ㄴ 리지드 바디가 없을 경우 물리 엔진의 도움을 받을 수 없다. -> 직접 구현을 해야 한다는 얘기

- 유니티는 게임 객ㅊ레에 리지드바디 컴포넌트가 포함되어 있을 경우 충돌 여부를 이벤트 형식으로 알려준다.
ㄴ 이 때 콜백 함수 호출이 발생한다.

컴파일러를 건너 뛰고 OS로 다이렉트로 쏘겠다. -> CallBack

- 유니티 엔진은 충돌체에 Is Trigger 옵션이 활성화되어 있을 경우 충돌 여부가 아닌 접촉 여부를 이벤트 형식으로
알려준다.

- 마지막으로 충돌 또는 접촉 여부의 이벤트 함수를 상호작용이 발생한 객체에 리지드 바디 컴포넌트가 포함되어 있을 경우에만
호출된다.

- 유니티 충돌과 트리거 관련 함수

- On 시리즈를 잘 기억하도록...

OnTriggerEnter(Collider other)
OnTriggerStay(Collider other)
OnTriggerExit(Collider other)

OnCollisionEnter(Collision other)
OnCollisionStay(Collision other)
OnCollisionExit(Collision other)


▷ 충돌 여부와 접촉 여부

- 충돌 여부란 물리 엔진에 의해서 물리 상호작용을 동반하는 것으로 OnCollision 계열 함수가 이벤트 형식으로
호출되며 접촉 여부는 물리 현상을 배제한 단순한 접촉의 결과에 대한 판정여부만을 OnTrigger 계열 함수의 이벤트 함수로 호출이 된다.


 주의점

- 유니티 엔진은 게임 객체에 충돌체만 포함되어 있을 경우 해당 객체를 정적 객체로 분류한다.
ㄴ 유니티에서 정적 객체는 내부적으로 퍼포먼스 향상을 위해 상태를 갱신하기 위해서는 반드시 별도의 로직이 필요하다.
 ㄴ 이에 해당 정적 객체를 수동으로 트랜스폼 등을 이용해서 상태를 변경했을 경우 내부적으로 이를 처리하기 위한 부하(프레임 드랍)가 발생한다.

정적 객체는 cpu가 처리하기 때문에 부하가 발생한다.

- 유니티는 게임 객체에 리지드바디 컴포넌트가 포함되어 있을 경우 해당 객체는 물리 엔진에 의해서 상태가 변경되는 것을
원칙으로 한다. 직접적으로 객체의 상태를 변경하면 내부적으로 부하가 발생한다.

- 하지만 직접적으로 상태를 변경하고 싶을 경우가 상당 수 되기 때문에 이때는 Is Kinematic 옵션을 활성화 해서
내부적으로 발생하는 부하를 없앨 수 있다. (단, 이 옵션이 활성화 될 경우 물리 엔진에 의한 연산 처리는 비활성화 된다.)


rigidbody 컴포넌트 속성

mass: 질량
drag: 공기저항(0이면 저항을 안 받는다)
ㄴ 0: 금속, 높으면 높을 수록 깃털

Angular drag: 공기 마찰력

use gravity: 중력 사용 여부

is kinematic: 충돌처리를 코드로 해줄거냐 엔진으로 해줄거냐

interpolate: 움직임이 부자연스러울 때
none
interpolate: 이전
extrapolate: 다음
ㄴ 보간할 때 사용
ㄴ 사용할 때 is kinematic을 켜야한다.

 보간 (Lerp)

- 두 점 사이의 중간 값에 대한 값을 예측하는 패턴 혹은 기법이라고 할 수 있다.

(v) a. 선형 보간(★★★★★)
ㄴ a점과 b점 사이에 선을 이으는 것
ㄴ transform에 많이 들어간다.

b. 이중 보간

c. 다항식 보간(되도록이면 찾아보지 말 것)

d. 포물선
ㄴ 곡선

(v) e. 스플라인
ㄴ 곡선

(v) f. 구면 보간(★★★★★)
ㄴ 애니메이션에 많이 들어간다.
ㄴ start와 end가 동일한 위치에 있는 것


collsion detection(충돌 감지)
ㄴ 일반적인 검사
continuous dynamic
discrete, continuous의 혼합(합쳐놓은 것)
ㄴ 매시 콜라이더에 충돌(오브젝트의 모양에 따라서 딱 맞게 충돌을 표현하겠다.
ㄴ 메시 콜라이더의 장점: 정밀도가 많다, 단점: 연산량이 굉장히 많다, 첫 충돌이 될 때만 충돌이 감지된다.(처음에 충돌이 안 되면 다시 충돌처리를 해줘야 함)

continuous speculative
ㄴ 예측, 추측해서 충돌을 하겠다.

physic material

dynamic friction
ㄴ 운동 마찰력

static friction
ㄴ 정지 마찰력


물리 제질 어떻게 표현할지
 */
#endregion

public class Example_03 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
