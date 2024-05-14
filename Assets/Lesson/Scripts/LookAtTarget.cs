using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    #region
    public GameObject target = null;
    #endregion

    void Update()
    {
        LookAtSample();
    }

    void LookAtSample()
    {
        // 공식: End - Start =  A와 B사이의 거리

        Vector3 directionToTarget = target.transform.position - this.transform.position; // 나와 상대방의 거리를 구하고
        this.transform.rotation = Quaternion.LookRotation(directionToTarget, Vector3.up); // 상대방의 위치에 따라 y축 방향으로 회전하겠다.
    }
}
