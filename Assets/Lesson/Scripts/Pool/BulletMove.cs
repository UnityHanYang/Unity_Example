using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    IEnumerator func;
    Coroutine BulletCoroutine;
    bool isFlying = true;
    Transform playerPos;

    void Awake()
    {
        playerPos = FindObjectOfType<PoolPlayer>().gameObject.transform;
        transform.position = playerPos.position;
    }

    void OnEnable()
    {
        func = Move();
        BulletCoroutine = StartCoroutine(func);
        transform.position = playerPos.position;
    }

    void OnDisable()
    {
        StopCoroutine(func);
    }

    IEnumerator Move()
    {
        StartCoroutine(Stop());

        while(isFlying)
        {
            transform.Translate(transform.forward * 10f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            // 애니메이션에서 WaitForEndOfFrame()를 많이 쓴다.
            // null로 바꿔도 상관 없음.
        }

        gameObject.SetActive(false);
        isFlying = true;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2f);
        isFlying = false;
    }
}
