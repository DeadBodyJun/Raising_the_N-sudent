using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Click()
    {
        GameManager.instance.Money += 2;          //게임매니저에 있는 지능값 증가
        Debug.Log("Money");
    }
    public void PartTimeJob()
    {
        GameManager.instance.Money += 1000;
        GameManager.instance.GameTime -= 3600;
    }
}
