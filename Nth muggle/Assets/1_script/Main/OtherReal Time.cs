// 다른 게임 씬에서도 시간 흐르는 스크립트
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherRealTime : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.GameTime -= Time.deltaTime*3600;                     // 게임 진행 시간을 델타타임을 더해서 계속 증가시킴

    }

}
