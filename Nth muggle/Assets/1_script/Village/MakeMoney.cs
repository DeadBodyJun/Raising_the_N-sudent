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
        GameManager.instance.AlbaClick ++; // Stress ��ũ��Ʈ ����
        Debug.Log("Money");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
