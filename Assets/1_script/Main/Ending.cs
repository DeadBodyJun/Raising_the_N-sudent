using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public void Start()
    {

    }

    public void Click()
    {
        GameManager.instance.Knolge += 2;          //게임매니저에 있는 지능값 증가
        Debug.Log("1");
    }

    public void Update()
    {
        if (Input.touchCount > 0)                                                               //터치 카운트가 0보다 클 경우, 즉 터치가 될 경우
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))        //만약 UI부분을 터치할 경우
            {
                return;                                                                         //아무 효과도 없음
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)                                //터치 1회 실행할 경우
                {
                    GameManager.instance.Knolge += 2;                                        //게임매니저의 지식값 2증가
                }
                if (GameManager.instance.GameTime == 0 && GameManager.instance.Knolge < 500)       //D-Day이고 지식값이 500이하일 경우
                {
                    SceneManager.LoadScene("TrueEnding");                                       //진엔딩Scene으로 이동
                }
                if (GameManager.instance.GameTime == 0 && GameManager.instance.Knolge < 100)      //D-Day이고 지식값이 100이하일 경우
                {
                    SceneManager.LoadScene("HappyEnding");                                      //진엔딩Scene으로 이동
                }
                if (GameManager.instance.Health < 0)                                            //건강값이 0이하일 경우
                {
                    SceneManager.LoadScene("PatientEnding");                                    //환자엔딩Scene으로 이동
                }
                if (GameManager.instance.Money < -10000)                                        //돈값이 -10000이하일 경우
                {
                    SceneManager.LoadScene("PoorEnding");                                       //거지엔딩Scene으로 이동
                }
            }
        }
    }
}