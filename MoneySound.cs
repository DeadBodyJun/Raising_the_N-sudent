using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMoney : MonoBehaviour
{
    public AudioSource audioSource;     // AudioSource ������Ʈ
    public AudioClip moneySound;        // ��ġ ȿ���� AudioClip

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Click()
    {
        GameManager.instance.Money += 2;          //���ӸŴ����� �ִ� ���ɰ� ����
        Debug.Log("Money");
        
        PlayMoneySound();   // ��ġ ȿ���� ���
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
