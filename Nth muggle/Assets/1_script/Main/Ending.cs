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

    public void Update()
    {
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
        
    }
}