using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 프리팹 (Prefab)
/*

▶ 프리팹

- 다양한 컴포넌트의 설정 값을 가진 게임 오브젝트를 다시 사용할 수 있도록 에셋으로 저장한 것

- 컴포넌트를 포함하고 있는 게임 객체의 원본을 미리 제작함으로써 특정 객체를 구성하기 위한 컴포넌트의 추가 및
변경을 손쉽게 관리할 수 있는 기능을 의미한다.

※ 유니티는 기본적으로 하이어라키에 있는 게임 오브젝트가 전부 현재 씬에 종속된다는 특징을 가지고 있다.


▷ 특징

- 유니티 엔진은 프리팹을 이용해서 객체의 조합을 미리 보관하는 것이 가능
ㄴ 프리팹을 사용하면 매번 객체의 조합을 구성하는 작업의 효율성을 높이는 것이 가능하다.

- 프리팹 원본에 변경 사항이 발생했을 경우 해당 변경 사항을 모두 사본 객체에 적용하는 것이 가능
ㄴ 작업 능률 / 편하다


  언제 사용하는가?

1. 다양한 컴포넌트를 추가하고 옵션 값을 변경한 오브젝트를 재활용하고 싶을 때
2. 내가 만드는 게임에 따라 오브젝트의 속성이 다른데 지속적으로 활용하고 싶을 때

  프리팹을 안 쓴다면?

- 효율성이 바닥을 찍는다...

- 씬을 변경하거나 새로운 오브젝트를 만들 때 계속해서 컴포넌트를 추가하고 옵션 값을 설정해야 하기 때문에...

복사가 수행할 때 얇게 할거냐 깊게 할거냐
얇게: 참조 형태만 가져올 때
ㄴ 주소값만 복사해놓은 상태

깊게: 원본 대상을 가지고 새로운 클론을 만드는 것
ㄴ 원본과는 다른 인스턴스를 만든다 -> 힙에다가

프리팹은 얕은 복사임.
 */
#endregion

public class CPrefabExample : MonoBehaviour
{
    #region 전역 변수
    public GameObject bulletObject;
    #endregion

    void Start()
    {

    }

    void Update()
    {
        //FireSample_01();
        //FireSample_02();
        //FireSample_03();
    }

    void FireSample_01()
    {
        // Instantiate(): 오브젝트를 복사한다 (객체 방식으로 생성)
        // ㄴ 원본 오브젝트를 복사해 클론 반환주는 메서드
        // ㄴ 인수: 대상 오브젝트, 오브젝트 위치, 오브젝트 회전값

        // Instantiate(bulletObject, transform.position, transform.rotation);

        // 리지드 바디
    }

    void FireSample_02()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject bullet = Instantiate(bulletObject, transform.position + transform.forward * 0.8f, transform.rotation);

            float bulletPower = 1500.0f;
            Vector3 direction = new(0.0f, 0.3f, 0.5f);

            bullet.GetComponent<Rigidbody>().AddForce(bulletPower * direction);
            bullet.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

            Destroy(bullet, 3.0f);
        }
    }

    void FireSample_03()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletObject, transform.position + transform.forward * 0.8f, transform.rotation);

            float bulletPower = 4000.0f;

            // TransformDirection(): 오브젝트가 어떤 방향을 바라보는지를
            Vector3 shootForward = bullet.transform.TransformDirection(Vector3.forward);
            // Trail: 궤적

            bullet.GetComponent<Rigidbody>().AddForce(bulletPower * shootForward);
            bullet.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

            Destroy(bullet, 3.0f);
        }
    }
}
