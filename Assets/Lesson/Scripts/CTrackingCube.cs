using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrackingCube : MonoBehaviour
{
    #region
    public GameObject target = null;
    public float distance = 5.0f;
    #endregion

    /*
    
    - RayCast (유니티에서는 물리 엔진 메서드)

    ◆ Ray: 광선
        ㄴ Ray: 광선
        ㄴ origin: 시작점
        ㄴ direction: 방향

    ※ 시작점으로부터 방향으로 광선을 거리만큼 쏜다.

     */

    private Ray ray;

    void Update()
    {
        TrackingSample();
    }

    void TrackingSample()
    {
        ray = new Ray(origin: this.transform.position, direction: this.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        Vector3 dirToTarget = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(dirToTarget, Vector3.up);
    }
}
