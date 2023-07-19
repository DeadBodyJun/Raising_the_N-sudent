// 시간 지나는 스크립트
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RealTime : MonoBehaviour
{
    public Text TimeText;       // 시간을 UI로 보여줄 Text형 변수
    private bool isScreenOn = true; // 화면 상태 저장
    private float ingTime = 0f; // 경과 시간
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
        Debug.Log("시작" + NowYear + "년" + NowMonth+ "월" + NowDay + "일" + NowHour + "시" + NowMinute + "분" + NowSecond + "초");
        Debug.Log("종료" + GameManager.instance.Year + "년" + GameManager.instance.Month + "월" + GameManager.instance.Day + "일"
            + GameManager.instance.Hour + "시" + GameManager.instance.Minute + "분" + GameManager.instance.Second + "초");
        Debug.Log("차이" + MinusYear + "년" + MinusMonth + "월" + MinusDay + "일" + MinusHour + "시" + MinusMinute + "분" + MinusSecond + "초");
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

        if (isScreenOn) // 화면이 켜져 있는 동안에만 실행
        {
            ingTime += Time.deltaTime; // 경과 시간 누적
            if (GameManager.instance.GameTime >= 0)
            {
                if (ingTime >= 1) // 2초 간격으로
                {
                    GameManager.instance.GameTime -= 1800;
                    ingTime = 0f; // 경과 시간 초기화
                }
            }
            else
            {
                GameManager.instance.GameTime = 31104000;   // 게임시간이 끝나면 다시 360일로 초기화
            }
            TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 86400 + "일";    // 초 값으로 저장된 게임시간을 일 값으로 바꿔서 text에 저장
        }
    }
}