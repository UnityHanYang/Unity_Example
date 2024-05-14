using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region
/*

�� Ʈ������ (ȸ��)

- ������ ����ؾ��� 4����

1. transform.Rotate
    �� ������Ʈ ȸ��

2. transform.RotateAround
    �� ���� ������Ʈ�� ���鼭 ȸ��

3. Quaternion
    �� ���Ҽ� / �� ���� -> (������ ������ �ذ��ϱ� ���� ���Ե� ����)
        �� (x, y, z, w(��Į��))
    �� ��Į�� �Ἥ ���� ���������� �����Ű�ڴ� -> ���� �����Ű�� �ʴ´�.
    �� ���Ϸ��� ���� ���귮�� ���� -> ���� ���� ���������� �����ϱ� ������ ������ ���� ���� ������� �ϱ� ������

4. EulerAngles
    �� ����: �ೢ�� ���������
    ���ʹϾ� ���� ���귮�� ��û ����(���Ϸ��� x�� ���� �ٸ� ���� �ǵ� �ʿ� ���� ���� ���� ����->�ѹ��� ȸ���ϸ� 3���� ���� ���� ������)
    �� ����: �ೢ�� ���������
    �� ���� ���� (Roll Pitch Yaw) -> ���� x(Roll), y(Pitch), z(Yaw)
        �� ȸ���� ���� �������� ������ �Ѵٴ� ���� ���� �������� �������� �߻� ��Ų��.

�� ������ (Gimbal Lock): x, y, z ������ ȸ���� �Ѵٰ� ������ �ϸ� y ȸ���� ���� ������ x������ ȸ���ߴ� ��� z���� �������� ���� -> ������ ��߳���.

 */
#endregion

public class RotateCube : MonoBehaviour
{
    #region
    public GameObject a;
    public GameObject target;
    #endregion
    void Start()
    {
        //RotateSample_01();
    }

    void Update()
    {
        //RotateSample_02();
        RotateAroundSample();
    }

    void RotateSample_01()
    {
        // ���ڸ� ȸ�� ģ����

        // eulerAngles: ���� �������� ���� ��ŭ ȸ�� (�⺻������ ������ �����Ǿ� �ִ�)
        this.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);

        // ���� ������ �ǹ��Ѵ�.
        // �� ���ڷ� ���� ������ ���Ϸ� ���� ���ʹϾ����� ��ȯ -> �Ű��������� �ַ� �Ǽ� / ����
        // ������Ƽ �����̱� ������ �ܵ����� ������ �� ����.
        // ���ʿ��� �������谡 �����.
        Quaternion target = Quaternion.Euler(45.0f, 45.0f, 45.0f);
        this.transform.rotation = target;
        
        // Rotate vs rotation ����
        // �� Rotate: ���Ӽ�
        // �� rotation: �ܹ߼�
        // �� Rotate(ȸ���� ���� ��ǥ �� * ��Ÿ Ÿ�� * (ȸ�� �ӵ�) * ())
        this.transform.Rotate(Vector3.up * 60.0f);
    }

    void RotateSample_02()
    {
        // AngleAxis: �� ������ �ޱ� ��ŭ ȸ���� �����̼��� �����ϰ� ��ȯ
        // �߽� ���� �Ǵ� axis�� y���� ��� y�࿡ ���� ȸ������ ������ �ʰ�  x, y�� ���� ���Ѵ�.

        this.transform.rotation *= Quaternion.AngleAxis(1.5f, Vector3.up);
    }

    void RotateAroundSample()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 40 * Time.deltaTime);
    }
}
