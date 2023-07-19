// �ð� ������ ��ũ��Ʈ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RealTime : MonoBehaviour
{
    public Text TimeText;       // �ð��� UI�� ������ Text�� ����
    private bool isScreenOn = true; // ȭ�� ���� ����
    private float ingTime = 0f; // ��� �ð�

    
    void Start()
    {
        Debug.Log(GameManager.instance.EndTime);
        Debug.Log(GameManager.instance.Second);
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.EndTime = DateTime.Now;
        DateTime Test = DateTime.Now;
        GameManager.instance.Second =Test.Second;


        if (isScreenOn) // ȭ���� ���� �ִ� ���ȿ��� ����
        {
            ingTime += Time.deltaTime; // ��� �ð� ����
            if (GameManager.instance.GameTime >= 0)
            {
                if (ingTime >= 1) // 2�� ��������
                {
                    GameManager.instance.GameTime -= 60;
                    ingTime = 0f; // ��� �ð� �ʱ�ȭ
                }
            }
            else
            {
                GameManager.instance.GameTime = 525600;   // ���ӽð��� ������ �ٽ� 365�Ϸ� �ʱ�ȭ
            }
            TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 1440 + "��";    // �� ������ ����� ���ӽð��� �� ������ �ٲ㼭 text�� ����
        }
    }
    private void OnApplicationQuit()
    {
        Debug.Log(GameManager.instance.EndTime);
        Debug.Log(GameManager.instance.Second);
    }

}