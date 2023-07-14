using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMoney : MonoBehaviour
{
    public AudioSource audioSource;     // AudioSource 컴포넌트
    public AudioClip moneySound;        // 터치 효과음 AudioClip

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Click()
    {
        GameManager.instance.Money += 2;          //게임매니저에 있는 지능값 증가
        Debug.Log("Money");
        
        PlayMoneySound();   // 터치 효과음 재생
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayMoneySound()
    {
        if (audioSource != null && moneySound != null)
        {
            audioSource.PlayOneShot(moneySound);
        }
    }
}
