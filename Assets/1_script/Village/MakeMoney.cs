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
        GameManager.instance.Money += 2;          //���ӸŴ����� �ִ� ���ɰ� ����
        Debug.Log("Money");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
