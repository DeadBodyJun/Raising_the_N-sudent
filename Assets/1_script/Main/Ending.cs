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
        if (GameManager.instance.GameTime == 0 && GameManager.instance.Knolge < 500)       //D-Day�̰� ���İ��� 500������ ���
        {
            SceneManager.LoadScene("TrueEnding");                                       //������Scene���� �̵�
        }
        if (GameManager.instance.GameTime == 0 && GameManager.instance.Knolge < 100)      //D-Day�̰� ���İ��� 100������ ���
        {
            SceneManager.LoadScene("HappyEnding");                                      //������Scene���� �̵�
        }
        if (GameManager.instance.Health < 0)                                            //�ǰ����� 0������ ���
        {
            SceneManager.LoadScene("PatientEnding");                                    //ȯ�ڿ���Scene���� �̵�
        }
        
    }
}