using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpendMoney : MonoBehaviour
{
    public int time=60;
    public void BuyLowBook()
    {
        GameManager.instance.Money -= 10000;
        GameManager.instance.TouchKnolge += 100;
    }
    public void BuyMiddleBook()
    {
        GameManager.instance.Money -= 100000;
        GameManager.instance.TouchKnolge += 500;
    }
    public void BuyHighBook()
    {
        GameManager.instance.Money -= 1000000;
        GameManager.instance.TouchKnolge += 1000;
    }
    public void BuyHp()
    {
        GameManager.instance.Money -= 5000;
        GameManager.instance.Health += 30;
    }
    public void BuyMp()
    {
        GameManager.instance.Money -= 5000;
        GameManager.instance.TouchKnolge = GameManager.instance.TouchKnolge * 5;
        BuffTime();
        GameManager.instance.TouchKnolge = GameManager.instance.TouchKnolge / 5;
    }
    IEnumerator BuffTime()
    {
        while (time >= 0) {
            yield return new WaitForSeconds(1);
            time--;
        }
        time = 60;
    }
}
