using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectController : MonoBehaviour
{
    #region 전역 변수

    public GameObject cubeObject = null;
    public float moveSpeed = 2.0f;

    #endregion
    public void Awake()
    {
        Debug.Log("너희의 빛...유니티");
        // 값만 찍을거면 printf가 유리하다

        // 1
        // GetComponent<T> 활용
        // 강한 형식 검사는 데이터 타입(int, float, string)을 뜻한다. (프로그램의 실수를 방지하겠다)
        // 약한 형식 검사는 var를 뜻한다.
        // ㄴ 지역 변수로만 선언 -> 선언과 동시에 반드시 초기화를 수행해야 한다.
        // ㄴ var는 C++의 auto와 비슷하다
        var transformObject = cubeObject.GetComponent<Transform>();
        transformObject.position = new Vector3(0.0f, 5.0f, 0.0f);

        var selftTransform = gameObject.GetComponent<Transform>();
        selftTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // 2
        // ㄴ 프로퍼티를 통해서 접근하는 방식
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        cubeObject.transform.position = new Vector3(0.0f, 0.0f, 5.0f);

        // 3.
        var oCubeObject = GameObject.Find("MoveCube");
        oCubeObject.AddComponent<CMoveForward>();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
    }
}
