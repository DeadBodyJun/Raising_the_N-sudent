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
    private int MinusYear;
    private int MinusMonth;
    private int MinusDay;
    private int MinusHour;
    private int MinusMinute;
    private int MinusSecond;


    void Start()
    {
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
                                MinusSecond = NowSecond - GameManager.instance.Second;
                            }                                                        
                            else
                            {
                                MinusSecond = 60 - (GameManager.instance.Second - NowSecond);
                                NowMinute--;
                            }
                            MinusMinute = NowMinute - GameManager.instance.Minute;
                        }
                        else
                        {
                            MinusMinute = 60 - (GameManager.instance.Minute - NowMinute);
                            NowHour--;
                        }
                        MinusHour = NowHour - GameManager.instance.Hour;
                    }
                    else
                    {
                        MinusHour = 24 - (GameManager.instance.Hour - NowHour);
                        NowDay--;
                    }
                    MinusDay = NowDay - GameManager.instance.Day;
                }
                else
                {
                    MinusDay = 30 - (GameManager.instance.Day - NowDay);
                    NowMonth--;
                }
                MinusMonth = NowMonth - GameManager.instance.Month;
            }
            else
            {
                MinusMonth = 12 - (GameManager.instance.Month - NowMonth);
                NowYear--;
            }
            MinusYear = NowYear - GameManager.instance.Year;
        }
        Debug.Log("����" + NowYear + "��" + NowMonth+ "��" + NowDay + "��" + NowHour + "��" + NowMinute + "��" + NowSecond + "��");
        Debug.Log("����" + GameManager.instance.Year + "��" + GameManager.instance.Month + "��" + GameManager.instance.Day + "��"
            + GameManager.instance.Hour + "��" + GameManager.instance.Minute + "��" + GameManager.instance.Second + "��");
        Debug.Log("����" + MinusYear + "��" + MinusMonth + "��" + MinusDay + "��" + MinusHour + "��" + MinusMinute + "��" + MinusSecond + "��");
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
                    GameManager.instance.GameTime -= 1800;
                    ingTime = 0f; // ��� �ð� �ʱ�ȭ
                }
            }
            else
            {
                GameManager.instance.GameTime = 31104000;   // ���ӽð��� ������ �ٽ� 360�Ϸ� �ʱ�ȭ
            }
            TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 86400 + "��";    // �� ������ ����� ���ӽð��� �� ������ �ٲ㼭 text�� ����
        }
    }
}