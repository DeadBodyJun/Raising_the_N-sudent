// ��ġ ���� �� ���ϴ� ��ũ��Ʈ
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
        GameManager.instance.Knolge += GameManager.instance.TouchKnolge;          //���ӸŴ����� �ִ� ���ɰ� ��ġ���ɰ� ��ġ ��ŭ ����

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
                    GameManager.instance.Knolge += GameManager.instance.TouchKnolge;
                }
            }
        }
    }
}