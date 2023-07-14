// 터치 지능 값 구하는 스크립트
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GetKnowledge : MonoBehaviour
{
    public void Start()
    {

    }

    public void Click()
    {
        GameManager.instance.Knolge += GameManager.instance.TouchKnolge;          //게임매니저에 있는 지능값 터치지능값 수치 만큼 증가

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
                    GameManager.instance.Knolge += GameManager.instance.TouchKnolge;
                }
            }
        }
    }
}