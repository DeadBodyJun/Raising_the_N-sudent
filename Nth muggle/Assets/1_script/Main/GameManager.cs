// �̱��� ����
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;               //static�� �����Ͽ� �ٸ� ������Ʈ ���� ��Ʈ��Ʈ������ ȣ�� ����
    public int Knolge;                                       //�⺻ ���� ��ġ
    public int Money;
    public float Health = 1f;
    public int Stress;
    public double GameTime = 31536000.0f;                    //���ӽð� 365���� �ʴ����� �ʱ�ȭ




    public void Awake()
    {

        if (instance == null)                                   //instance�� NULL, �ý��� �󿡼� instance�� �������� ���� ��
        {
            instance = this;                                    //�� �ڽſ� instance�� ����
            DontDestroyOnLoad(gameObject);                      //OnLoad(���� �ε� �Ǿ��� ��) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this)                               //�� �ڽ��� instance�� �ƴ� ��� �̹� instance�� �ϳ� �����ϴ� �ǹ�
            {
                Destroy(this.gameObject);                       //�� �̻� �����ϸ� �ȵǹǷ� ��� Awake�� �� �ڽ��� ����
            }
        }
    }
}