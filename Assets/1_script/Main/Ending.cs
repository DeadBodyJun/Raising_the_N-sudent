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
        GameManager.instance.Knolge += 2;          //���ӸŴ����� �ִ� ���ɰ� ����
        Debug.Log("1");
    }

    public void Update()
    {
        if (Input.touchCount > 0)                                                               //��ġ ī��Ʈ�� 0���� Ŭ ���, �� ��ġ�� �� ���
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))        //���� UI�κ��� ��ġ�� ���
            {
                return;                                                                         //�ƹ� ȿ���� ����
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)                                //��ġ 1ȸ ������ ���
                {
                    GameManager.instance.Knolge += 2;                                        //���ӸŴ����� ���İ� 2����
                }
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
                if (GameManager.instance.Money < -10000)                                        //������ -10000������ ���
                {
                    SceneManager.LoadScene("PoorEnding");                                       //��������Scene���� �̵�
                }
            }
        }
    }
}