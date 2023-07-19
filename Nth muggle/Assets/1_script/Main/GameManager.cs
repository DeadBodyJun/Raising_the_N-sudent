// �̱��� ����,Json
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public int Knolge;
    public int Money;
    public float Health;
    public int Stress;
    public double GameTime;
    public int BuffTime;
    public int Year;
    public int Month;
    public int Day;
    public int Hour;
    public int Minute;
    public int Second;
    //������ GameManager���� ������ �������� ���⿡�� �߰��ؾ���.
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;               //static�� �����Ͽ� �ٸ� ������Ʈ ���� ��Ʈ��Ʈ������ ȣ�� ����
    public int Knolge;                                       //�⺻ ���� ��ġ
    public int Money;
    public float Health = 1f;
    public int Stress = 0;
    public double GameTime = 31104000;                    //���ӽð� 360�Ϸ� �ʱ�ȭ
    public int BuffTime = 50;
    public int Year;
    public int Month;
    public int Day;
    public int Hour;
    public int Minute;
    public int Second;

    private string savePath;

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

        // ������ ���� ��� ����
        savePath = Application.persistentDataPath + "/playerData.json";

        // ���� ���� �� ����� ������ �ҷ�����
        LoadPlayerData();
        Debug.Log(savePath); // DB ������ �ܼ� ���
    }

    // �����͸� JSON���� ����ȭ�Ͽ� �����ϴ� �Լ�
    private void SavePlayerData(PlayerData playerData)
    {
        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(savePath, jsonData);
    }

    // JSON�� ������ȭ�Ͽ� �����͸� �ҷ����� �Լ�
    private void LoadPlayerData()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(jsonData);

            // �ҷ��� �����͸� ���� ������ ����
            Knolge = loadedData.Knolge;
            Money = loadedData.Money;
            Health = loadedData.Health;
            Stress = loadedData.Stress;
            GameTime = loadedData.GameTime;
            BuffTime = loadedData.BuffTime;
            Year = loadedData.Year;
            Month = loadedData.Month;
            Day = loadedData.Day;  
            Hour = loadedData.Hour;
            Minute = loadedData.Minute;
            Second = loadedData.Second;
            //������ GameManager���� ������ �������� ���⿡�� �߰��ؾ���.
        }
    }

    // ���� ���� �ÿ� ȣ��Ǵ� �Լ�
    private void save()
    {
        PlayerData playerData = new PlayerData
        {
            Knolge = Knolge,
            Money = Money,
            Health = Health,
            Stress = Stress,
            GameTime = GameTime,
            BuffTime = BuffTime,
            Year = Year,
            Month = Month,
            Day = Day,
            Hour = Hour,
            Minute = Minute,
            Second = Second
            //������ GameManager���� ������ �������� ���⿡�� �߰��ؾ���.

        };

        SavePlayerData(playerData);
    }
    public void Update()
    {
        save();
    }
}