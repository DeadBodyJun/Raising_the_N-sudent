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
    private int NowYear;
    private int NowMonth;
    private int NowDay;
    private int NowHour;
    private int NowMinute;
    private int NowSecond;

    void Start()
    {
        Debug.Log(GameManager.instance.EndTime);
        NowYear = DateTime.Now.Year;
        NowMonth = DateTime.Now.Month;
        NowDay = DateTime.Now.Day;
        NowHour = DateTime.Now.Hour;
        NowMinute = DateTime.Now.Minute;
        NowSecond = DateTime.Now.Second;
        if(NowYear > GameManager.instance.Year)
        {
            if(NowMonth >= GameManager.instance.Month)
            {
                if(NowDay >= GameManager.instance.Day)
                {
                    if(NowHour >= GameManager.instance.Hour)
                    {
                        if(NowMinute >= GameManager.instance.Minute)
                        {
                            if(NowSecond >= GameManager.instance.Second)
                            {
                                NowSecond = NowSecond - GameManager.instance.Second; // 2023/7/19/11/34/50
                            }                                                        // 2024/4/20/8/56/30
                            else
                            {
                                NowSecond = 60 - (GameManager.instance.Second - NowSecond);
                                NowMinute--;
                            }
                            NowMinute = NowMinute - GameManager.instance.Minute;
                        }
                        else
                        {
                            NowMinute = 60 - (GameManager.instance.Minute - NowMinute);
                            NowHour--;
                        }
                        NowHour = NowHour - GameManager.instance.Hour;
                    }
                    else
                    {
                        NowHour = 24 - (GameManager.instance.Hour - NowHour);
                        NowDay--;
                    }
                    NowDay = NowDay - GameManager.instance.Day;
                }
                else
                {
                    NowDay = 30 - (GameManager.instance.Day - NowDay);
                    NowMonth--;
                }
                NowMonth = NowMonth - GameManager.instance.Month;
            }
            else
            {
                NowMonth = 12 - (GameManager.instance.Month - NowMonth);
                NowYear--;
            }
            NowYear = NowYear - GameManager.instance.Year;
        }
        Debug.Log(NowYear);
        Debug.Log(NowMonth);
        Debug.Log(NowDay);
        Debug.Log(NowHour);
        Debug.Log(NowMinute);
        Debug.Log(NowSecond);
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.Second = DateTime.Now.Year;
        GameManager.instance.Second = DateTime.Now.Month;
        GameManager.instance.Second = DateTime.Now.Day;
        GameManager.instance.Second = DateTime.Now.Hour;
        GameManager.instance.Second = DateTime.Now.Minute;
        GameManager.instance.Second = DateTime.Now.Second;

        if (isScreenOn) // ȭ���� ���� �ִ� ���ȿ��� ����
        {
            ingTime += Time.deltaTime; // ��� �ð� ����
            if (GameManager.instance.GameTime >= 0)
            {
                if (ingTime >= 1) // 2�� ��������
                {
                    GameManager.instance.GameTime -= 900;
                    ingTime = 0f; // ��� �ð� �ʱ�ȭ
                }
            }
            else
            {
                GameManager.instance.GameTime = 31104000;   // ���ӽð��� ������ �ٽ� 360�Ϸ� �ʱ�ȭ
            }
            TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 360 + "��";    // �� ������ ����� ���ӽð��� �� ������ �ٲ㼭 text�� ����
        }
    }
    private void OnApplicationQuit()
    {

    }

}