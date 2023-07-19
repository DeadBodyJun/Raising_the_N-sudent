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
    public int TouchStress;
    public int AlbaClick;
    //������ GameManager���� ������ �������� ���⿡�� �߰��ؾ���.
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;               //static�� �����Ͽ� �ٸ� ������Ʈ ���� ��Ʈ��Ʈ������ ȣ�� ����
    public float Knolge=0;                                       //�⺻ ���� ��ġ
    public int Money=0;
    public float Health = 1f;
    public int Stress = 0;
    public double GameTime = 31536000.0f;                    //���ӽð� 365���� �ʴ����� �ʱ�ȭ
    public int BuffTime = 50;
    public float TouchKnolge = 0;
    public int TouchStress = 0;              // Stress ��ũ��Ʈ
    public int AlbaClick = 0;               // Stress ��ũ��Ʈ


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
    public GameManager player;
    public float OriginalKnologe = 2f;
    public GameObject BuffPreFab;

    void Start()
    {
       // player.Knolge = OriginalKnologe;
       
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
                player.TouchKnolge = BuffChange(type, OriginalKnologe);
                break;
        }
    }

    public void CreateBuff(string type, float per, float du)//, Sprite icon)
    {
        GameObject go = Instantiate(BuffPreFab, transform);
        go.GetComponent<BaseBuff>().Init(type, per, du);
        // go.GetComponent<UnityEngine.UI.Image>().sprite = icon;
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
            TouchKnolge = loadedData.TouchKnolge;
            TouchStress = loadedData.TouchStress;
            AlbaClick = loadedData.AlbaClick;
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
            BuffTime = BuffTime,
            TouchKnolge = TouchKnolge,
            TouchStress = TouchStress,
            AlbaClick = AlbaClick

            //������ GameManager���� ������ �������� ���⿡�� �߰��ؾ���. ������ ���� �޸� ���� �� ��.
        };
        SavePlayerData(playerData);
    }
}