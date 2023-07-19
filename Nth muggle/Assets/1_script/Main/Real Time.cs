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


        if (isScreenOn) // 화면이 켜져 있는 동안에만 실행
        {
            ingTime += Time.deltaTime; // 경과 시간 누적
            if (GameManager.instance.GameTime >= 0)
            {
                if (ingTime >= 1) // 2초 간격으로
                {
                    GameManager.instance.GameTime -= 60;
                    ingTime = 0f; // 경과 시간 초기화
                }
            }
            else
            {
                GameManager.instance.GameTime = 525600;   // 게임시간이 끝나면 다시 365일로 초기화
            }
            TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 1440 + "일";    // 초 값으로 저장된 게임시간을 일 값으로 바꿔서 text에 저장
        }
    }
    private void OnApplicationQuit()
    {
        Debug.Log(GameManager.instance.EndTime);
        Debug.Log(GameManager.instance.Second);
    }

}