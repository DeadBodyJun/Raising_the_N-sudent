// 지능 값 text 표시하는 스크립트
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OtherKnowledgeCount : MonoBehaviour
{

    public Text Count;
    public GameObject Knowledge;
    public Button Touch;
    public bool isScreenOn = true; // 화면 상태 저장
    private GameManager gameManager; // GameManager 참조
    private float ingTime = 0f; // 경과 시간

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isScreenOn) // 화면이 켜져 있는 동안에만 실행
        {
            ingTime += Time.deltaTime; // 경과 시간 누적

            if (ingTime >= 0.5) // 0.5초 간격으로
            {
                GameManager.instance.Knolge += 1;
                ingTime = 0f; // 경과 시간 초기화
            }
        }
    }
    public void OnApplicationFocus(bool focus)
    {
        isScreenOn = focus; // 화면이 켜져 있다는 뜻
    }
}
