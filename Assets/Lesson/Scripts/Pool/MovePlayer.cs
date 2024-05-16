using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 0;
    
    // ����Ƽ ��ũ��Ʈ�� �����ϰ� ó������ ������ start, update �Ӹ� �ƴ϶�, ondestroy, awake �޼��� ���.. �̷� �޼����
    // �ּ�ó���� �ص� ������ ������ ����� �� �� �� ������ �������Ѵ�.
    // call back���� ������


    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(-hori * Time.deltaTime * speed, upDown * Time.deltaTime * speed, 0f);

        transform.Translate(move);
    }
}
