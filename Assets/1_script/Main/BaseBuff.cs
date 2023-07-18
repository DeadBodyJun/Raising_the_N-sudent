using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBuff : MonoBehaviour
{
    public string Type;                                            //목표
    public float Percentage = 0.5f;                                //변형정도
    public float Duration = 10f;
    public float Currenttime = 10f;
    // public Image Icon;

    public void Awake()
    {
        // Icon = GetComponent<Image>();
    }

    public void Init(string type, float per, float du)             //초기화
    {
        this.Type = type;
        Percentage = per;
        Duration = du;
        Currenttime = Duration;
       // Icon.fillAmount = 1;
        Execute();
    }
    WaitForSeconds seconds = new WaitForSeconds(0.1f);
    public void Execute()                                           //버프 실행
    {
        GameManager.instance.onBuff.Add(this);
        GameManager.instance.ChooseBuff(Type);
        StartCoroutine(Activation());
    }

    IEnumerator Activation()                                       //버프 타이머
    {
        while (Currenttime > 0)
        {
            Currenttime -= 0.1f;
          //  Icon.fillAmount = Currenttime / Duration;
            yield return seconds;
        }
       // Icon.fillAmount = 0;
        Currenttime = 0;
        DeActivation();
    }

    public void DeActivation()                                    //버프삭제
    {
        GameManager.instance.onBuff.Remove(this);
        GameManager.instance.ChooseBuff(Type);
        Destroy(gameObject);
    }
}
