using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveCube : MonoBehaviour
{
    #region 전역 변수

    public GameObject cubeObject = null;
    public float moveSpeed = 2.0f;

    #endregion
    // 타 컴포넌트와는 독립적으로 동작하는 객체
    void Start()
    {
        //MoveSample_01();
    }

    void Update()
    {
        //MoveSample_02();
        MoveSample_03();
        CubeJump();
    }

    void MoveSample_01()
    {
        //transform.position = new Vector3(0.0f, 5.0f, 0.0f); // 월드 좌표계


        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f)); // 로컬 좌표계
        // ㄴ 오브젝트가 회전이 되면 회전된 오브젝트 위쪽에 따라 올라간다)
        // 할당을 받으면 프로퍼티(Get)가 아닐까
    }

    void MoveSample_02()
    {
        float moveDelta = moveSpeed * Time.deltaTime;
        Vector3 pos = this.transform.position;

        pos.z += moveDelta;
        this.transform.position = pos;

        //================

        moveDelta = this.moveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveSpeed);
        // ㄴ Translate가 들어가면 로컬좌표계라는 뜻

        // 소문자 translate는 UI할 때 쓴다.

        // 유니티에서는 정규화 백터를 지원한다.
        // Vector(기하학 백터)
        // 크기 + 방향을 가진 데이터 타입
        // ㄴ 정규화 백터들의 특징은 모두 노말라이즈가 되어 있다
        // -> 노말라이즈가 되어 있다는 것 -> 이게 바로 백터의 정규화를 뜻한다.(단위 백터)
        // - Vector3(1, 1, 1)
        // 작고 가까운 오브젝트는 연산이 적게 들어간다.
        // 객체의 스케일에 따라서 결과가 달라진다.
        // 백터끼리는 중첩이 된다. (1, 1, 1)로 해야될게 (2, 2, 2)로 되어 2배가 이동된다. -> 이런 문제점 때문에 정규화를 사용해야한다.

        /*
         Vector3(1, 0, 0);        -> Vector3.right
         Vector3(-1, 0, 0);       -> Vector3.left
         
        Vector3(0, 1, 0);         -> Vector3.up
        Vector3(0, -1, 0);        -> Vector3.down

        Vector3(0, 0, 1);         -> Vector3.forward
        Vector3(0, 0, -1);        -> Vector3.back

        Vector3(0, 0, 0);         -> Vector3.zero (원점 (이동 x))
        Vector3(1, 1, 1);         -> Vector3.one (세축으로 이동)

        관련 클래스 맴버
            Vector3.Dot(A, B)         ->     내적
            Vector3.Cross(A, B)       ->     외적
            Vector3.Distance          ->     거리차이 (A와 B)
            Vector3.Angle             ->     각도차 (Degree)


        인스턴스 맴버
            Vector3.Normalize()
            Vector3.Magintude()        ->   백터의 길이를 알려주는 프로퍼티
            Vector3.SqrMagintude()     ->   백터의 길이 제곱을 알려주는 프로퍼티 -> 빠르다.


         */
        // 백터의 내적각, 외적각을 알아서 구해준다.
        // 백터의 내적, 외적 공부하기
    }

    void MoveSample_03()
    {
        var cubePosition = cubeObject.transform.position;

        /*
        GetAxis / GetAxisRaw

        - 넘겨받는 매개 변수의 문자열을 통해서 키보드나 조이스틱의 입력 값을 -1 ~ +1 사이의 값으로 반환

        GetAxis: 즉각적인 반응(적을 발견하면 바로 공격할 때 사용)
        GetAxisRaw: 자연스러운 움직임
        */
        float fDeltaX = Input.GetAxisRaw("Horizontal");
        float fDeltaZ = Input.GetAxisRaw("Vertical");

        Debug.LogFormat("DeltaX: {0}", fDeltaX);

        //cubePosition.x += fDeltaX * 5.0f * Time.deltaTime;
        //cubePosition.y += fDeltaZ * 5.0f * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            cubePosition.x -= 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cubePosition.x += 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cubePosition.z += 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            cubePosition.z -= 5.0f * Time.deltaTime;
        }
        cubeObject.transform.position = cubePosition;
    }

    void CubeJump()
    {
        if (Input.GetMouseButton(1))
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 0.5f, 0.0f);
            velocity = velocity * power;
            this.GetComponent<Rigidbody>().velocity = velocity;

        }
        if (Input.GetMouseButton(1))
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 2.0f, 0.0f);
            velocity = velocity * power;
            this.GetComponent<Rigidbody>().AddForce(velocity);

        }
    }
}
