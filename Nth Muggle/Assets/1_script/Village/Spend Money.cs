using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpendMoney : MonoBehaviour
{
    public string Type;                 //목표
    public float Percentage;            //변형정도
    public float Duration;
    // public Sprite Icon;

    public void BuyLowBook()
    {
        if (GameManager.instance.Money > 0)
        {
            GameManager.instance.Money -= 10;
            GameManager.instance.TouchKnolge += 100;
        }
        else
            return;
    }
    public void BuyMiddleBook()
    {
        if (GameManager.instance.Money > 0)
        {
            GameManager.instance.Money -= 100;
            GameManager.instance.TouchKnolge += 500;
        }
        else
            return;
    }
    public void BuyHighBook()
    {
        if (GameManager.instance.Money > 0)
        {
            GameManager.instance.Money -= 1000;
            GameManager.instance.TouchKnolge += 1000;
        }
        else
            return;
    }
    public void BuyHp()
    {
        if (GameManager.instance.Money > 0)
        {
            GameManager.instance.Money -= 5000;
            GameManager.instance.Health += 30;
        }
        else
            return;
    }
    
}