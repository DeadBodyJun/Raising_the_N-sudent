// 싱글톤 패턴
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;               //static을 선언하여 다른 오브젝트 안의 스트립트에서도 호출 가능
    public int Knolge;                                       //기본 지능 수치
    public int Money;
    public float Health = 1f;
    public int Stress;
    public double GameTime = 31536000.0f;                    //게임시간 365일을 초단위로 초기화




    public void Awake()
    {

        if (instance == null)                                   //instance가 NULL, 시스템 상에서 instance가 존재하지 않을 때
        {
            instance = this;                                    //내 자신에 instance를 삽입
            DontDestroyOnLoad(gameObject);                      //OnLoad(씬이 로드 되었을 때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this)                               //내 자신이 instance가 아닐 경우 이미 instance가 하나 존재하단 의미
            {
                Destroy(this.gameObject);                       //둘 이상 존재하면 안되므로 방금 Awake가 된 자신을 삭제
            }
        }
    }
}