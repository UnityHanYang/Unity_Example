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
        // PingPong: �ּ� ���� �ִ� �� ���̸� �ݺ�
        // PingPong(float t, float length)
        // ������ ���� �� ����. -> ���̸� 4�� ���ָ� �ִ밪�� 3.999 �̷����� �ȴ� -> 4�� �� ���´ٴ� ��
        // time: ������ �� �������� ī��Ʈ�� �����Ѵ� (Play �ð� ����)
        transform.position = new Vector3(Mathf.PingPong(Time.time*2, 4), transform.position.y, transform.position.z);
    }
}
