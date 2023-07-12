// 시간 지나는 스크립트
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RealTime : MonoBehaviour
{
    public Text TimeText;       // 시간을 UI로 보여줄 Text형 변수

    void Start()
    {
        if (PlayerPrefs.HasKey("GameTime"))   //    GameTime키가 저장돼 있는지 확인
        {
            GameManager.instance.GameTime = DoubleFromString(PlayerPrefs.GetString("GameTime"));    // D-day(GameTime)값이 저장돼 있으면 불러온다.
        }

        // 게임 시작 시 저장되어 있던 값을 불러옴
        DateTime PrevQuitTime;         // 이전 종료시간 저장할 DateTime 변수
        if (PlayerPrefs.HasKey("GameQuitTime"))     // GameQuitTime키가 저장돼 있는지 확인
        {
            PrevQuitTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("GameQuitTime")));     // 종료시간을 DateTime변수로 변환하고 PrevQuitTime에 저장
            TimeSpan difference = DateTime.Now - PrevQuitTime;      // 시작시간 - 이전 종료시간 을 difference에 저장
            int DifTime = (int)difference.TotalSeconds;    // difference를 초단위 인트값으로 바꾸고 DifTime에 저장
            Debug.Log("종료된 시간: " + DifTime);        // 종료돼 있던 시간 값 표시
            DifTime = DifTime*3600; // 종료돼 있던 시간 값 (조정)
            Debug.Log("종료시간 * 3600: " + DifTime);   // 조정한 종료시간 표시
            Debug.Log("게임시간: " + (int)GameManager.instance.GameTime);    // 종료시간 빼기 전 게임시간
            GameManager.instance.GameTime = GameManager.instance.GameTime - DifTime;    // 게임시간에 종료시간 빼서 저장
            Debug.Log("바뀐 게임시간: " + (int)GameManager.instance.GameTime);    // 종료시간 뺀 후 게임시간
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.GameTime -= Time.deltaTime*3600;   // 게임시간 흐르게 함 (조정)
        if (GameManager.instance.GameTime < 0)      
        {
            GameManager.instance.GameTime = 31536000.0f;   // 게임시간이 끝나면 다시 365일로 초기화
        }
        TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 86400 + "일";    // 초 값으로 저장된 게임시간을 일 값으로 바꿔서 text에 저장
    }
    void OnApplicationQuit()
    {
        // 게임 종료 시 현재의 시간을 저장
        PlayerPrefs.SetString("GameQuitTime", Convert.ToString(DateTime.Now.ToBinary()));
        // 게임 종료 시 GameTime 변수의 값을 저장 (double)
        PlayerPrefs.SetString("GameTime", StringFromDouble(GameManager.instance.GameTime));
        // PlayerPrefs 저장
        PlayerPrefs.Save(); 
    }
    // string 값을 double값으로 변환
    private double DoubleFromString(string value)
    {
        return double.Parse(value);
    }

    // double 값을 문자열로 변환
    private string StringFromDouble(double value)
    {
        return value.ToString();
    }
}
