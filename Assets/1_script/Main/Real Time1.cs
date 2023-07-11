using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTime1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.GameTime -= Time.deltaTime;                      // 게임 진행 시간을 델타타임을 더해서 계속 증가시킴

    }

}
