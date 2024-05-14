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
        // ����: End - Start =  A�� B������ �Ÿ�

        Vector3 directionToTarget = target.transform.position - this.transform.position; // ���� ������ �Ÿ��� ���ϰ�
        this.transform.rotation = Quaternion.LookRotation(directionToTarget, Vector3.up); // ������ ��ġ�� ���� y�� �������� ȸ���ϰڴ�.
    }
}
