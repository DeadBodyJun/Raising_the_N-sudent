// �ǰ� ��ġ ü�¹�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherHealth : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if(GameManager.instance.Health < 100)
        {
            GameManager.instance.Health += Time.deltaTime/3;  // �ǰ��� �ִ�ġ�� �ƴϸ� ���� ��
        }
    }
}
