// �ð� ������ ��ũ��Ʈ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RealTime : MonoBehaviour
{
    public Text TimeText;       // �ð��� UI�� ������ Text�� ����
    public bool isScreenOn = true; // ȭ�� ���� ����
    private float ingTime = 0f; // ��� �ð�
    private DateTime StartTime;

    void Start()
    {
        Debug.Log(GameManager.instance.EndTime);
    }

    // Update is called once per frame
    void Update()
    {
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
            if (GameManager.instance.GameTime < 0)
            {
                GameManager.instance.GameTime = 525600;   // ���ӽð��� ������ �ٽ� 365�Ϸ� �ʱ�ȭ
            }
            TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 1440 + "��";    // �� ������ ����� ���ӽð��� �� ������ �ٲ㼭 text�� ����
        }
    }
    void OnApplicationQuit()
    {
        GameManager.instance.EndTime = DateTime.Now.ToString();
        Debug.Log(GameManager.instance.EndTime);
    }
}