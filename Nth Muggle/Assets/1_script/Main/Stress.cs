// ��Ʈ���� (���α���) �ڵ�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress : MonoBehaviour
{
    private float ingTime = 0f; // ��� �ð�

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("��Ʈ����");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.Stress < 0)
        {
            GameManager.instance.Stress = 0;
        }
        
        if (GameManager.instance.Stress < 100)
        {
            ingTime += Time.deltaTime; // ��� �ð� ����

            if (ingTime >= 2) // 2�� ��������
            {
                GameManager.instance.Stress--;
                ingTime = 0; // ��� �ð� �ʱ�ȭ
            }
        }

        if (GameManager.instance.Stress >= 100)
        {
            GameManager.instance.Stress -= 100; // stress 100 ���� ��, �ʱ�ȭ
            GameManager.instance.Health -= 10;
        }

        // GameManager.instance.TouchStress ������ KnowledgeCount ��ũ��Ʈ�� �߰���
        if (GameManager.instance.TouchStress > 100)
        {
            GameManager.instance.Stress += 5; // ��ġ 100ȸ ��, ��Ʈ���� 5����
            GameManager.instance.TouchStress = 0; // ��ġ ī��Ʈ �ʱ�ȭ
        }

        // GameManager.instance.AlbaClick ������ MakeMoney ��ũ��Ʈ�� �߰���
        if (GameManager.instance.AlbaClick > 0)
        {
            GameManager.instance.Stress += 20 * GameManager.instance.AlbaClick;
            GameManager.instance.AlbaClick = 0;
        }
    }
}
