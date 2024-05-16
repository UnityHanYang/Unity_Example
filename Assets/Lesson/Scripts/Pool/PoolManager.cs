using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // C++에서의 전방 선언
    ObjecPolling instancePool;
    PoolPlayer player;
    bool pressed = false;

    void Start()
    {
        instancePool = FindObjectOfType<ObjecPolling>();
        player = FindObjectOfType<PoolPlayer>();
        // find함수들은 기본적으로 무겁다..(GetComponent 포함)
        // GetComponent는 하어라이키창 부터 찾고
        // FindObjectOfType는 Project창에서 부터 찾는다.
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !pressed)
        {
            player.pressed = true;
            pressed = true;
        }

        if(player.pressed)
        {
            StartCoroutine(Shoot());
            player.pressed = false;
        }
    }

    // IEnumerator: 열거형(enum)을 참조형태로 사용하겠다.
    // 코루틴은 비동기이기 때문에 Update가 동작하는 것과 상관이 없다.
    // 플레이어 움직임을 제어해주기 아주 좋다.
    // ㄴ wasd나 점프 등등.. 키를 Update 안에서 제어할 때는 if문을 계속 써서 검사해줘야했다 -> 키를 안 눌러도 검사를 해야하니까 메모리 낭비가 높다.
    // 하지만 코루틴을 사용해서 제어해주면 매번 검사할 필요가 없다.
    // 코루틴은 비동기 형식이므로 코루틴을 보내는쪽, 받는쪽 둘다 비동기 형식으로 적어야한다.
    IEnumerator Shoot()
    {
        while(true)
        {
            instancePool.SpawnObj();
            yield return new WaitForSeconds(.3f);
        }
        // yield: 양보
        // C++에서의 튜플과 비슷하다
        // n개 이상의 리턴값을 줄 수 있다.
    }
}
