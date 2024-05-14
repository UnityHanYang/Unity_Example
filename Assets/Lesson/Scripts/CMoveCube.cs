using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveCube : MonoBehaviour
{
    #region ���� ����

    public GameObject cubeObject = null;
    public float moveSpeed = 2.0f;

    #endregion
    // Ÿ ������Ʈ�ʹ� ���������� �����ϴ� ��ü
    void Start()
    {
        //MoveSample_01();
    }

    void Update()
    {
        //MoveSample_02();
        MoveSample_03();
        CubeJump();
    }

    void MoveSample_01()
    {
        //transform.position = new Vector3(0.0f, 5.0f, 0.0f); // ���� ��ǥ��


        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f)); // ���� ��ǥ��
        // �� ������Ʈ�� ȸ���� �Ǹ� ȸ���� ������Ʈ ���ʿ� ���� �ö󰣴�)
        // �Ҵ��� ������ ������Ƽ(Get)�� �ƴұ�
    }

    void MoveSample_02()
    {
        float moveDelta = moveSpeed * Time.deltaTime;
        Vector3 pos = this.transform.position;

        pos.z += moveDelta;
        this.transform.position = pos;

        //================

        moveDelta = this.moveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveSpeed);
        // �� Translate�� ���� ������ǥ���� ��

        // �ҹ��� translate�� UI�� �� ����.

        // ����Ƽ������ ����ȭ ���͸� �����Ѵ�.
        // Vector(������ ����)
        // ũ�� + ������ ���� ������ Ÿ��
        // �� ����ȭ ���͵��� Ư¡�� ��� �븻����� �Ǿ� �ִ�
        // -> �븻����� �Ǿ� �ִٴ� �� -> �̰� �ٷ� ������ ����ȭ�� ���Ѵ�.(���� ����)
        // - Vector3(1, 1, 1)
        // �۰� ����� ������Ʈ�� ������ ���� ����.
        // ��ü�� �����Ͽ� ���� ����� �޶�����.
        // ���ͳ����� ��ø�� �ȴ�. (1, 1, 1)�� �ؾߵɰ� (2, 2, 2)�� �Ǿ� 2�谡 �̵��ȴ�. -> �̷� ������ ������ ����ȭ�� ����ؾ��Ѵ�.

        /*
         Vector3(1, 0, 0);        -> Vector3.right
         Vector3(-1, 0, 0);       -> Vector3.left
         
        Vector3(0, 1, 0);         -> Vector3.up
        Vector3(0, -1, 0);        -> Vector3.down

        Vector3(0, 0, 1);         -> Vector3.forward
        Vector3(0, 0, -1);        -> Vector3.back

        Vector3(0, 0, 0);         -> Vector3.zero (���� (�̵� x))
        Vector3(1, 1, 1);         -> Vector3.one (�������� �̵�)

        ���� Ŭ���� �ɹ�
            Vector3.Dot(A, B)         ->     ����
            Vector3.Cross(A, B)       ->     ����
            Vector3.Distance          ->     �Ÿ����� (A�� B)
            Vector3.Angle             ->     ������ (Degree)


        �ν��Ͻ� �ɹ�
            Vector3.Normalize()
            Vector3.Magintude()        ->   ������ ���̸� �˷��ִ� ������Ƽ
            Vector3.SqrMagintude()     ->   ������ ���� ������ �˷��ִ� ������Ƽ -> ������.


         */
        // ������ ������, �������� �˾Ƽ� �����ش�.
        // ������ ����, ���� �����ϱ�
    }

    void MoveSample_03()
    {
        var cubePosition = cubeObject.transform.position;

        /*
        GetAxis / GetAxisRaw

        - �Ѱܹ޴� �Ű� ������ ���ڿ��� ���ؼ� Ű���峪 ���̽�ƽ�� �Է� ���� -1 ~ +1 ������ ������ ��ȯ

        GetAxis: �ﰢ���� ����(���� �߰��ϸ� �ٷ� ������ �� ���)
        GetAxisRaw: �ڿ������� ������
        */
        float fDeltaX = Input.GetAxisRaw("Horizontal");
        float fDeltaZ = Input.GetAxisRaw("Vertical");

        Debug.LogFormat("DeltaX: {0}", fDeltaX);

        //cubePosition.x += fDeltaX * 5.0f * Time.deltaTime;
        //cubePosition.y += fDeltaZ * 5.0f * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            cubePosition.x -= 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cubePosition.x += 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cubePosition.z += 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            cubePosition.z -= 5.0f * Time.deltaTime;
        }
        cubeObject.transform.position = cubePosition;
    }

    void CubeJump()
    {
        if (Input.GetMouseButton(1))
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 0.5f, 0.0f);
            velocity = velocity * power;
            this.GetComponent<Rigidbody>().velocity = velocity;

        }
        if (Input.GetMouseButton(1))
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 2.0f, 0.0f);
            velocity = velocity * power;
            this.GetComponent<Rigidbody>().AddForce(velocity);

        }
    }
}
