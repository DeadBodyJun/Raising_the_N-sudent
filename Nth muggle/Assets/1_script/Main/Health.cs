// �ǰ� ��ġ ü�¹�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;

public class Health : MonoBehaviour
{
    public Image Bar; // �̹��� ������Ʈ.
    private float Percent;      // ä��� ����
    public float MaxHealth = 100f;  // �ִ� ü��
    void Start()
    {

    }
    void Update()
    {
        if (GameManager.instance.Health < 100)
        {
            GameManager.instance.Health += Time.deltaTime / 3;  // �ǰ��� �ִ�ġ�� �ƴϸ� ���� ��
        }
        Percent = GameManager.instance.Health / MaxHealth; //�ִ� hp���� ���� hp
        Bar.fillAmount = Percent; // ä��� ���� = �ۼ�Ʈ

    }
    public void HpClick()
    {
        if(GameManager.instance.Health < 90)
        {
            GameManager.instance.Health += 10;          // Hp���� ���� �ǰ� �� 10 ����
        }
        Debug.Log("Hp");
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
