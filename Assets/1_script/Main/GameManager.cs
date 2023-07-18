// �̱��� ����
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
    public float Knolge;
    public int Money;
    public float Health;
    public int Stress;
    public double GameTime;
    public int BuffTime;
    public float TouchKnolge;
    //������ GameManager���� ������ �������� ���⿡�� �߰��ؾ���.
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;               //static�� �����Ͽ� �ٸ� ������Ʈ ���� ��Ʈ��Ʈ������ ȣ�� ����
    public float Knolge;                                       //�⺻ ���� ��ġ
    public int Money;
    public float Health = 1f;
    public int Stress = 0;
    public double GameTime = 31536000.0f;                    //���ӽð� 365���� �ʴ����� �ʱ�ȭ
    public int BuffTime = 50;
    public float TouchKnolge;

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
    public PlayerData player;
    public float OriginalKnologe = 2;
   

    void Start()
    {
        player.Knolge = OriginalKnologe;
       
    }

    public List<BaseBuff> onBuff = new List<BaseBuff>();           //��� onBuff���·� �����߰�

    public float BuffChange(string type, float origin)
    {
        if (onBuff.Count > 0)
        {
            float temp = 0;
            for (int i = 0; i < onBuff.Count; i++)
            {
                if (onBuff[i].Type.Equals(type))
                    temp += origin * onBuff[i].Percentage;
            }
            return origin + temp;
        }
        else
        {
            return origin;
        }
    }

    public void ChooseBuff(string type)
    {
        switch (type)
        {
            case "Mp":
                player.Knolge = BuffChange(type, OriginalKnologe);
                break;
        }
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

            //������ GameManager���� ������ �������� ���⿡�� �߰��ؾ���.
        }
    }

    // ���� ���� �ÿ� ȣ��Ǵ� �Լ�
    private void OnApplicationQuit()
    {
        PlayerData playerData = new PlayerData
        {
            Knolge = Knolge,
            Money = Money,
            Health = Health,
            Stress = Stress,
            GameTime = GameTime,
            BuffTime = BuffTime

            //������ GameManager���� ������ �������� ���⿡�� �߰��ؾ���.
        };
        SavePlayerData(playerData);
    }
}