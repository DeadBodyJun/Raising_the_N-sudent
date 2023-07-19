using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMp : MonoBehaviour
{
    public string Type= "TouchKnolge";  //��ǥ
    public float Percentage = 2f;            //��������
    public float Duration = 10f;
    // public Sprite Icon;

    public void MpBuy()
    {
        if (GameManager.instance.Money > 0)
        {
            GameManager.instance.Money -= 10;
            GameManager.instance.CreateBuff(Type, Percentage, Duration);//, Icon);
        }
        else
            return;
    }
}