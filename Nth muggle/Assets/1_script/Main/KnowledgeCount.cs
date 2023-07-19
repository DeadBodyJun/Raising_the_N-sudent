// ���� �� text ǥ���ϴ� ��ũ��Ʈ
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KnowledgeCount : MonoBehaviour
{

    public Text Count;
    public bool isScreenOn = true; // ȭ�� ���� ����
    private float ingTime = 0f; // ��� �ð�

    void Start()
    {

    }

    void Update()
    {
        Count.text = "���� : " + GameManager.instance.Knolge;
        if (isScreenOn) // ȭ���� ���� �ִ� ���ȿ��� ����
        {
            ingTime += Time.deltaTime; // ��� �ð� ����

            if (ingTime >= 0.5) // 0.5�� ��������
            {
                GameManager.instance.Knolge += 1;
                ingTime = 0f; // ��� �ð� �ʱ�ȭ
            }
        }

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
                }
            }
        }
    }
    /*���� �𸣰ھ �ϴ� ����� GetKnowledge ��ũ��Ʈ �ܾ��
    public void Click()
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
                    GameManager.instance.Knolge += GameManager.instance.TouchKnolge;        //���ӸŴ����� �ִ� ���ɰ� ����
                    GameManager.instance.TouchStress ++;                                      // Stress ��ũ��Ʈ ����
                }
            }
        }          
    }

    public void OnApplicationFocus(bool focus)
    {
        isScreenOn = focus; // ȭ���� ���� �ִٴ� ��
    }
    */

    public void Click()
    {
        GameManager.instance.Knolge += 2;          //���ӸŴ����� �ִ� ���ɰ� ����
        GameManager.instance.TouchStress++;     // Stress ��ũ��Ʈ ����
    }
}
