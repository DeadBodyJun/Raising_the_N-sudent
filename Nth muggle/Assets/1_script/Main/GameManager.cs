// 싱글톤 패턴
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
    //앞으로 GameManager에서 관리할 변수들은 여기에도 추가해야함.
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;               //static을 선언하여 다른 오브젝트 안의 스트립트에서도 호출 가능
    public float Knolge=0;                                       //기본 지능 수치
    public int Money=0;
    public float Health = 1f;
    public int Stress = 0;
    public double GameTime = 31536000.0f;                    //게임시간 365일을 초단위로 초기화
    public int BuffTime = 50;
    public float TouchKnolge = 0;
    public int TouchStress = 0;              // Stress 스크립트
    public int AlbaClick = 0;               // Stress 스크립트


    private string savePath;

    public void Awake()
    {

        if (instance == null)                                   //instance가 NULL, 시스템 상에서 instance가 존재하지 않을 때
        {
            instance = this;                                    //내 자신에 instance를 삽입
            DontDestroyOnLoad(gameObject);                      //OnLoad(씬이 로드 되었을 때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this)                               //내 자신이 instance가 아닐 경우 이미 instance가 하나 존재하단 의미
            {
                Destroy(this.gameObject);                       //둘 이상 존재하면 안되므로 방금 Awake가 된 자신을 삭제
            }
        }

        // 데이터 저장 경로 설정
        savePath = Application.persistentDataPath + "/playerData.json";

        // 게임 시작 시 저장된 데이터 불러오기
        LoadPlayerData();
        Debug.Log(savePath); // DB 저장경로 콘솔 출력
    }
    public GameManager player;
    public float OriginalKnologe = 2f;
    public GameObject BuffPreFab;

    void Start()
    {
       // player.Knolge = OriginalKnologe;
       
    }

    public List<BaseBuff> onBuff = new List<BaseBuff>();           //대상에 onBuff형태로 버프추가

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

    // 데이터를 JSON으로 직렬화하여 저장하는 함수
    private void SavePlayerData(PlayerData playerData)
    {
        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(savePath, jsonData);
    }

    // JSON을 역직렬화하여 데이터를 불러오는 함수
    private void LoadPlayerData()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(jsonData);

            // 불러온 데이터를 현재 변수에 적용
            Knolge = loadedData.Knolge;
            Money = loadedData.Money;
            Health = loadedData.Health;
            Stress = loadedData.Stress;
            GameTime = loadedData.GameTime;
            BuffTime = loadedData.BuffTime;
            TouchKnolge = loadedData.TouchKnolge;
            TouchStress = loadedData.TouchStress;
            AlbaClick = loadedData.AlbaClick;
    //앞으로 GameManager에서 관리할 변수들은 여기에도 추가해야함.
}
    }

    // 게임 종료 시에 호출되는 함수
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

            //앞으로 GameManager에서 관리할 변수들은 여기에도 추가해야함. 마지막 줄은 콤마 쓰지 말 것.
        };
        SavePlayerData(playerData);
    }
}