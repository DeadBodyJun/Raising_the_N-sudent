// ���� �� text ǥ���ϴ� ��ũ��Ʈ
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KnowledgeCount : MonoBehaviour
{

    public Text Count;
    public GameObject Knowledge;
    public Button Touch;
    public bool isScreenOn = true; // ȭ�� ���� ����
    private GameManager gameManager; // GameManager ����
    private float ingTime = 0f; // ��� �ð�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
    }
    public void TouchButton()
    {
        GameManager.instance.Knolge += 5;
        //Debug.Log("��ġ");
    }

    public void OnApplicationFocus(bool focus)
    {
        isScreenOn = focus; // ȭ���� ���� �ִٴ� ��
    }
}
