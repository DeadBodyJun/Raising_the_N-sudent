// �ǰ� ��ġ ü�¹�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;


public class Health : MonoBehaviour
{
    int button2SoundIndex = 1;

    public Image Bar; // �̹��� ������Ʈ.
    private float Percent;      // ä��� ����
    public float MaxHealth = 100f;  // �ִ� ü��
    public bool isScreenOn = true; // ȭ�� ���� ����
    private float ingTime = 0f; // ��� �ð�
    

    void Start()
    {

    }
    void Update()
    {
        if (isScreenOn) // ȭ���� ���� �ִ� ���ȿ��� ����
        {
            ingTime += Time.deltaTime; // ��� �ð� ����
            if (GameManager.instance.Health <= 99)
            {
                if (ingTime >= 2) // 2�� ��������
                {
                    GameManager.instance.Health += 1;
                    ingTime = 0f; // ��� �ð� �ʱ�ȭ
                }
            }
           
            Percent = GameManager.instance.Health / MaxHealth; //�ִ� hp���� ���� hp
            Bar.fillAmount = Percent; // ä��� ���� = �ۼ�Ʈ
        }
    }
    
    public void HpClick()
    {
        if(GameManager.instance.Health < 90)
        {
            GameManager.instance.Health += 10;          // Hp���� ���� �ǰ� �� 10 ����
        }
        Debug.Log("Hp");
        SFXManager.Instance.PlayButtonTouchSound(button2SoundIndex);
    }
    public void MpClick()
    {
        if (GameManager.instance.Health > 7)
        {
            GameManager.instance.Health -= 5;          // Mp���� ���� �ǰ� �� 5 ����
            Debug.Log("Mp");
        }
    }
}
