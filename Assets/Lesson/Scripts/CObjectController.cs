using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectController : MonoBehaviour
{
    #region ���� ����

    public GameObject cubeObject = null;
    public float moveSpeed = 2.0f;

    #endregion
    public void Awake()
    {
        Debug.Log("������ ��...����Ƽ");
        // ���� �����Ÿ� printf�� �����ϴ�

        // 1
        // GetComponent<T> Ȱ��
        // ���� ���� �˻�� ������ Ÿ��(int, float, string)�� ���Ѵ�. (���α׷��� �Ǽ��� �����ϰڴ�)
        // ���� ���� �˻�� var�� ���Ѵ�.
        // �� ���� �����θ� ���� -> ����� ���ÿ� �ݵ�� �ʱ�ȭ�� �����ؾ� �Ѵ�.
        // �� var�� C++�� auto�� ����ϴ�
        var transformObject = cubeObject.GetComponent<Transform>();
        transformObject.position = new Vector3(0.0f, 5.0f, 0.0f);

        var selftTransform = gameObject.GetComponent<Transform>();
        selftTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // 2
        // �� ������Ƽ�� ���ؼ� �����ϴ� ���
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        cubeObject.transform.position = new Vector3(0.0f, 0.0f, 5.0f);

        // 3.
        var oCubeObject = GameObject.Find("MoveCube");
        oCubeObject.AddComponent<CMoveForward>();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
    }
}
