// 지능 값 text 표시하는 스크립트
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KnowledgeCount : MonoBehaviour
{

    public Text Count;
    public Button Touch;
    public bool isScreenOn = true; // 화면 상태 저장
    private GameManager gameManager; // GameManager 참조
    private float ingTime = 0f; // 경과 시간

    void Start()
    {

    }

    void Update()
    {
        Count.text = "지능 : " + GameManager.instance.Knolge;
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
    public void Click()
    {
        if (Input.touchCount > 0)                                                          //터치 카운트가 0보다 클 경우, 즉 터치가 될 경우
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))    //만약 UI부분을 터치할 경우
            {
                return;                                                                     //아무 효과도 없음
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)                            //터치 1회 실행할 경우
                {
                    GameManager.instance.Knolge += GameManager.instance.TouchKnolge;        //게임매니저에 있는 지능값 증가

                    Debug.Log("knowledge");
                }
            }
        }          
    }

    public void OnApplicationFocus(bool focus)
    {
        isScreenOn = focus; // 화면이 켜져 있다는 뜻
    }
}
