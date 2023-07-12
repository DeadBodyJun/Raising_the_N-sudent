// 건강 수치 체력바
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;

public class Health : MonoBehaviour
{
    public Image Bar; // 이미지 컴포넌트.
    private float Percent;      // 채우는 정도
    public float MaxHealth = 100f;  // 최대 체력
    void Start()
    {
        
    }
    void Update()
    {
        if(GameManager.instance.Health < 100)
        {
            GameManager.instance.Health += Time.deltaTime/3;  // 건강이 최대치가 아니면 증가 됨
        }
        Percent = GameManager.instance.Health /MaxHealth; //최대 hp분의 현재 hp
        Bar.fillAmount = Percent; // 채우는 정도 = 퍼센트

    }
    public void HpClick()
    {
        GameManager.instance.Health += 10;          // Hp물약 사용시 건강 값 10 증가
        Debug.Log("Hp");
    }
    public void MpClick()
    {
        GameManager.instance.Health -= 5;          // Mp물약 사용시 건강 값 5 감소
        Debug.Log("Mp");
    }
}
