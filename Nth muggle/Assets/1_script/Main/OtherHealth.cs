// 건강 수치 체력바
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherHealth : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if(GameManager.instance.Health < 100)
        {
            GameManager.instance.Health += Time.deltaTime/3;  // 건강이 최대치가 아니면 증가 됨
        }
    }
}
