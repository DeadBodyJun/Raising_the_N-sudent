// 스트레스 (내부구현) 코드
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress : MonoBehaviour
{
    private float ingTime = 0f; // 경과 시간

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("스트레스");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.Stress < 0)
        {
            GameManager.instance.Stress = 0;
        }
        
        if (GameManager.instance.Stress < 100)
        {
            ingTime += Time.deltaTime; // 경과 시간 누적

            if (ingTime >= 2) // 2초 간격으로
            {
                GameManager.instance.Stress--;
                ingTime = 0; // 경과 시간 초기화
            }
        }

        if (GameManager.instance.Stress >= 100)
        {
            GameManager.instance.Stress -= 100; // stress 100 도달 시, 초기화
            GameManager.instance.Health -= 10;
        }

        // GameManager.instance.TouchStress 증가는 KnowledgeCount 스크립트에 추가함
        if (GameManager.instance.TouchStress > 100)
        {
            GameManager.instance.Stress += 5; // 터치 100회 시, 스트레스 5증가
            GameManager.instance.TouchStress = 0; // 터치 카운트 초기화
        }

        // GameManager.instance.AlbaClick 증가는 MakeMoney 스크립트에 추가함
        if (GameManager.instance.AlbaClick > 0)
        {
            GameManager.instance.Stress += 20 * GameManager.instance.AlbaClick;
            GameManager.instance.AlbaClick = 0;
        }
    }
}
