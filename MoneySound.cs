using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMoney : MonoBehaviour
{
    int button1SoundIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void Click()
    {
        GameManager.instance.Money += 2;          //게임매니저에 있는 지능값 증가
        Debug.Log("Money");
        SFXManager.Instance.PlayButtonTouchSound(button1SoundIndex);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
