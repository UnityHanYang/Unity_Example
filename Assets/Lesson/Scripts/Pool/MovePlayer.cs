using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 0;
    
    // 유니티 스크립트를 생성하고 처음부터 적히는 start, update 뿐만 아니라, ondestroy, awake 메서드 등등.. 이런 메서드는
    // 주석처리를 해도 먹히지 않으니 사용을 안 할 땐 무조건 지워야한다.
    // call back으로 돼있음


    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(-hori * Time.deltaTime * speed, upDown * Time.deltaTime * speed, 0f);

        transform.Translate(move);
    }
}
