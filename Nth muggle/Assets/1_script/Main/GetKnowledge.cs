// ��ġ ���� �� ���ϴ� ��ũ��Ʈ
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
    
    public bool isScreenOn = true; // ȭ�� ���� ����
    private float ingTime = 0f; // ��� �ð�

    public void Start()
    {
        GameManager.instance.Knolge += GameManager.instance.TotalMinus / 1;  // �������ᵿ�� ���� ���� ��
    }
    public void Update()
    {
        if (Input.touchCount > 0)                                                          //��ġ ī��Ʈ�� 0���� Ŭ ���, �� ��ġ�� �� ���
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))    //���� UI�κ��� ��ġ�� ���
            {
                return;                                                                     //�ƹ� ȿ���� ����
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)                            //��ġ 1ȸ ������ ���
                {
                    GameManager.instance.Knolge += 2;
                    //Debug.Log("knowledge");
                }
            }
        }
        if (isScreenOn) // ȭ���� ���� �ִ� ���ȿ��� ����
        {
            ingTime += Time.deltaTime; // ��� �ð� ����

            if (ingTime >= 1) // 1�� ��������
            {
                GameManager.instance.Knolge += 1;
                ingTime = 0f; // ��� �ð� �ʱ�ȭ
            }
        }
        Count.text = "���� : " + GameManager.instance.Knolge;
    }
    public void OnApplicationFocus(bool focus)
    {
        isScreenOn = focus; // ȭ���� ���� �ִٴ� ��
    }
}