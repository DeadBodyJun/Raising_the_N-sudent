// 건강 수치 체력바
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;


public class Health : MonoBehaviour
{
    int button2SoundIndex = 1;

    public Image Bar; // 이미지 컴포넌트.
    private float Percent;      // 채우는 정도
    public float MaxHealth = 100f;  // 최대 체력
    public bool isScreenOn = true; // 화면 상태 저장
    private float ingTime = 0f; // 경과 시간
    

    void Start()
    {

    }
    void Update()
    {
        if (isScreenOn) // 화면이 켜져 있는 동안에만 실행
        {
            ingTime += Time.deltaTime; // 경과 시간 누적
            if (GameManager.instance.Health <= 99)
            {
                if (ingTime >= 2) // 2초 간격으로
                {
                    GameManager.instance.Health += 1;
                    ingTime = 0f; // 경과 시간 초기화
                }
            }
           
            Percent = GameManager.instance.Health / MaxHealth; //최대 hp분의 현재 hp
            Bar.fillAmount = Percent; // 채우는 정도 = 퍼센트
        }
    }
    
    public void HpClick()
    {
        if(GameManager.instance.Health < 90)
        {
            GameManager.instance.Health += 10;          // Hp물약 사용시 건강 값 10 증가
        }
        Debug.Log("Hp");
        SFXManager.Instance.PlayButtonTouchSound(button2SoundIndex);
    }
    public void MpClick()
    {
        if (GameManager.instance.Health > 7)
        {
            GameManager.instance.Health -= 5;          // Mp물약 사용시 건강 값 5 감소
            Debug.Log("Mp");
        }
    }
}
