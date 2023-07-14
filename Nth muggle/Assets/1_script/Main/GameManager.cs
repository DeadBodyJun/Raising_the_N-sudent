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
    public int Knolge = 0;                                       //�⺻ ���� ��ġ
    public int Money = 0;
    public int Health = 0;
    public int Stress = 0;
    public double GameTime = 31536000.0f;                    //���ӽð� 365���� �ʴ����� �ʱ�ȭ
    public int TouchKnolge = 2;                             // ��ġ ����
    public int BuffTime = 10;

    public IEnumerator Time()
    {
        while (BuffTime > 0)
        {
            yield return new WaitForSeconds(1);
            BuffTime--;
        }
    }


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