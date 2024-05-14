using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region
/*

▶ 트랜스폼 (회전)

- 앞으로 기억해야할 4가지

1. transform.Rotate
    ㄴ 오브젝트 회전

2. transform.RotateAround
    ㄴ 기준 오브젝트를 보면서 회전

3. Quaternion
    ㄴ 복소수 / 사 원수 -> (짐벌락 현상을 해결하기 위해 도입된 수식)
        ㄴ (x, y, z, w(스칼라))
    ㄴ 스칼라를 써서 축을 독립적으로 수행시키겠다 -> 축을 연결시키지 않는다.
    ㄴ 오일러에 비해 연산량이 많음 -> 축이 각각 독립적으로 수행하기 때문에 각각의 축을 따로 돌려줘야 하기 때문에

4. EulerAngles
    ㄴ 장점: 축끼리 연결돼있음
    쿼터니언에 비해 연산량이 엄청 적음(오일러는 x가 돌면 다른 축을 건들 필요 없이 같이 돌기 때문->한번만 회전하면 3개의 축이 돌기 때문에)
    ㄴ 단점: 축끼리 연결돼있음
    ㄴ 고정 각도 (Roll Pitch Yaw) -> 각각 x(Roll), y(Pitch), z(Yaw)
        ㄴ 회전한 축을 기준으로 다음을 한다는 점이 고정 각도와의 차이점을 발생 시킨다.

★ 짐벌락 (Gimbal Lock): x, y, z 순서로 회전을 한다고 가정을 하면 y 회전에 의해 이전에 x축으로 회전했던 축과 z축익 같아지는 현상 -> 각도가 어긋난다.

 */
#endregion

public class RotateCube : MonoBehaviour
{
    #region
    public GameObject a;
    public GameObject target;
    #endregion
    void Start()
    {
        //RotateSample_01();
    }

    void Update()
    {
        //RotateSample_02();
        RotateAroundSample();
    }

    void RotateSample_01()
    {
        // 제자리 회전 친구들

        // eulerAngles: 축을 기준으로 각도 만큼 회전 (기본적으로 각도는 고정되어 있다)
        this.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);

        // 절대 각도를 의미한다.
        // ㄴ 인자로 들어온 백터의 오일러 값을 쿼터니언으로 변환 -> 매개변수에는 주로 실수 / 백터
        // 프로퍼티 형식이기 때문에 단독으로 실행할 수 없다.
        // 불필요한 참조관계가 생긴다.
        Quaternion target = Quaternion.Euler(45.0f, 45.0f, 45.0f);
        this.transform.rotation = target;
        
        // Rotate vs rotation 차이
        // ㄴ Rotate: 지속성
        // ㄴ rotation: 단발성
        // ㄴ Rotate(회전할 기준 좌표 축 * 델타 타임 * (회전 속도) * ())
        this.transform.Rotate(Vector3.up * 60.0f);
    }

    void RotateSample_02()
    {
        // AngleAxis: 축 주위를 앵글 만큼 회전한 로테이션을 생성하고 반환
        // 중심 축이 되는 axis가 y축일 경우 y축에 대한 회전값은 변하지 않고  x, y의 값만 변한다.

        this.transform.rotation *= Quaternion.AngleAxis(1.5f, Vector3.up);
    }

    void RotateAroundSample()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 40 * Time.deltaTime);
    }
}
