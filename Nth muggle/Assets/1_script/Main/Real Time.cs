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

        if (isScreenOn) // 화면이 켜져 있는 동안에만 실행
        {
            ingTime += Time.deltaTime; // 경과 시간 누적
            if (GameManager.instance.GameTime >= 0)
            {
                if (ingTime >= 1) // 2초 간격으로
                {
                    GameManager.instance.GameTime -= 900;
                    ingTime = 0f; // 경과 시간 초기화
                }
            }
            else
            {
                GameManager.instance.GameTime = 31104000;   // 게임시간이 끝나면 다시 360일로 초기화
            }
            TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 360 + "일";    // 초 값으로 저장된 게임시간을 일 값으로 바꿔서 text에 저장
        }
    }
    private void OnApplicationQuit()
    {

    }

}