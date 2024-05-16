using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // C++������ ���� ����
    ObjecPolling instancePool;
    PoolPlayer player;
    bool pressed = false;

    void Start()
    {
        instancePool = FindObjectOfType<ObjecPolling>();
        player = FindObjectOfType<PoolPlayer>();
        // find�Լ����� �⺻������ ���̴�..(GetComponent ����)
        // GetComponent�� �Ͼ����Űâ ���� ã��
        // FindObjectOfType�� Projectâ���� ���� ã�´�.
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

    // IEnumerator: ������(enum)�� �������·� ����ϰڴ�.
    // �ڷ�ƾ�� �񵿱��̱� ������ Update�� �����ϴ� �Ͱ� ����� ����.
    // �÷��̾� �������� �������ֱ� ���� ����.
    // �� wasd�� ���� ���.. Ű�� Update �ȿ��� ������ ���� if���� ��� �Ἥ �˻�������ߴ� -> Ű�� �� ������ �˻縦 �ؾ��ϴϱ� �޸� ���� ����.
    // ������ �ڷ�ƾ�� ����ؼ� �������ָ� �Ź� �˻��� �ʿ䰡 ����.
    // �ڷ�ƾ�� �񵿱� �����̹Ƿ� �ڷ�ƾ�� ��������, �޴��� �Ѵ� �񵿱� �������� ������Ѵ�.
    IEnumerator Shoot()
    {
        while(true)
        {
            instancePool.SpawnObj();
            yield return new WaitForSeconds(.3f);
        }
        // yield: �纸
        // C++������ Ʃ�ð� ����ϴ�
        // n�� �̻��� ���ϰ��� �� �� �ִ�.
    }
}
