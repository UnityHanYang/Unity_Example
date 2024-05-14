using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatrollCube : MonoBehaviour
{
    void Update()
    {
        PatrollSample();
    }

    void PatrollSample()
    {
        // PingPong: 최소 값과 최대 값 사이를 반복
        // PingPong(float t, float length)
        // 마지막 값은 안 들어간다. -> 길이를 4로 해주면 최대값은 3.999 이런식이 된다 -> 4가 안 나온다는 뜻
        // time: 선언이 된 시점부터 카운트를 시작한다 (Play 시간 누적)
        transform.position = new Vector3(Mathf.PingPong(Time.time*2, 4), transform.position.y, transform.position.z);
    }
}
