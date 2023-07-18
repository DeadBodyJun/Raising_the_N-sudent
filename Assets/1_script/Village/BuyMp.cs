using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public string Type;                 //목표
    public float Percentage;            //변형정도
    public float Duration;
    // public Sprite Icon;

    public void BuyMp()
    {
        if (GameManager.instance.Money > 0)
        {
            GameManager.instance.Money -= 100;
            BuffManager.instance.CreateBuff(Type, Percentage, Duration);//, Icon);
        }
        else
            return;
    }
}