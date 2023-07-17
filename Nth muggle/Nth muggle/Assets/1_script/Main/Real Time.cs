// �ð� ������ ��ũ��Ʈ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RealTime : MonoBehaviour
{
    public Text TimeText;       // �ð��� UI�� ������ Text�� ����

    void Start()
    {
        if (PlayerPrefs.HasKey("GameTime"))   //    GameTimeŰ�� ����� �ִ��� Ȯ��
        {
            GameManager.instance.GameTime = DoubleFromString(PlayerPrefs.GetString("GameTime"));    // D-day(GameTime)���� ����� ������ �ҷ��´�.
        }

        // ���� ���� �� ����Ǿ� �ִ� ���� �ҷ���
        DateTime PrevQuitTime;         // ���� ����ð� ������ DateTime ����
        if (PlayerPrefs.HasKey("GameQuitTime"))     // GameQuitTimeŰ�� ����� �ִ��� Ȯ��
        {
            PrevQuitTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("GameQuitTime")));     // ����ð��� DateTime������ ��ȯ�ϰ� PrevQuitTime�� ����
            TimeSpan difference = DateTime.Now - PrevQuitTime;      // ���۽ð� - ���� ����ð� �� difference�� ����
            int DifTime = (int)difference.TotalSeconds;    // difference�� �ʴ��� ��Ʈ������ �ٲٰ� DifTime�� ����
            Debug.Log("����� �ð�: " + DifTime);        // ����� �ִ� �ð� �� ǥ��
            DifTime = DifTime*3600; // ����� �ִ� �ð� �� (����)
            Debug.Log("����ð� * 3600: " + DifTime);   // ������ ����ð� ǥ��
            Debug.Log("���ӽð�: " + (int)GameManager.instance.GameTime);    // ����ð� ���� �� ���ӽð�
            GameManager.instance.GameTime = GameManager.instance.GameTime - DifTime;    // ���ӽð��� ����ð� ���� ����
            Debug.Log("�ٲ� ���ӽð�: " + (int)GameManager.instance.GameTime);    // ����ð� �� �� ���ӽð�
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.GameTime -= Time.deltaTime*3600;   // ���ӽð� �帣�� �� (����)
        if (GameManager.instance.GameTime < 0)      
        {
            GameManager.instance.GameTime = 31536000.0f;   // ���ӽð��� ������ �ٽ� 365�Ϸ� �ʱ�ȭ
        }
        TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 86400 + "��";    // �� ������ ����� ���ӽð��� �� ������ �ٲ㼭 text�� ����
    }
    void OnApplicationQuit()
    {
        // ���� ���� �� ������ �ð��� ����
        PlayerPrefs.SetString("GameQuitTime", Convert.ToString(DateTime.Now.ToBinary()));
        // ���� ���� �� GameTime ������ ���� ���� (double)
        PlayerPrefs.SetString("GameTime", StringFromDouble(GameManager.instance.GameTime));
        // PlayerPrefs ����
        PlayerPrefs.Save(); 
    }
    // string ���� double������ ��ȯ
    private double DoubleFromString(string value)
    {
        return double.Parse(value);
    }

    // double ���� ���ڿ��� ��ȯ
    private string StringFromDouble(double value)
    {
        return value.ToString();
    }
}
