// 터치 지능 값 구하는 스크립트
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GetKnowledge : MonoBehaviour
{

    public Text Count;
    
    public bool isScreenOn = true; // 화면 상태 저장
    private float ingTime = 0f; // 경과 시간

    public void Start()
    {
        GameManager.instance.Knolge += GameManager.instance.TotalMinus / 1;  // 게임종료동안 오른 지능 값
    }
    public void Update()
    {
        if (Input.touchCount > 0)                                                          //터치 카운트가 0보다 클 경우, 즉 터치가 될 경우
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))    //만약 UI부분을 터치할 경우
            {
                return;                                                                     //아무 효과도 없음
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)                            //터치 1회 실행할 경우
                {
                    GameManager.instance.Knolge += 2;
                    //Debug.Log("knowledge");
                }
            }
        }
        if (isScreenOn) // 화면이 켜져 있는 동안에만 실행
        {
            ingTime += Time.deltaTime; // 경과 시간 누적

            if (ingTime >= 1) // 1초 간격으로
            {
                GameManager.instance.Knolge += 1;
                ingTime = 0f; // 경과 시간 초기화
            }
        }
        Count.text = "지능 : " + GameManager.instance.Knolge;
    }
    public void OnApplicationFocus(bool focus)
    {
        isScreenOn = focus; // 화면이 켜져 있다는 뜻
    }
}