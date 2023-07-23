using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    [Range(0, 20)]
    public float MoneyTime = 10.0f;
    [Range(0, 20)]
    public float MoneyCoolTime = 10.0f;

    public float CoolTime;

    //public Text MoneyCoolTimeText;

    bool isUseSkill = true;

    /*private void Awake()
    {
        skillInformationText.text = "Skill OFF";
        MoneyCoolTimeText.text = "Skill";
    }*/

    public void Click() //�Ƹ�����Ʈ Ŭ��
    {
        if (isUseSkill == true)
        {
            isUseSkill = false;

            //MoneyCoolTimeText.text = "";
            CoolTime = 1;
            GameManager.instance.Money += 10;
            GameManager.instance.Health -= 5;
            StartCoroutine(SkillCoroutine());
        }
        else
            return;
    }
    IEnumerator SkillCoroutine() //��ų �����
    {
        while (CoolTime > 0)
        {
            CoolTime -= 1 * Time.smoothDeltaTime / MoneyTime;
            yield return null;
        }

        StartCoroutine(ResetSkillCoroutine());
        //StartCoroutine(CoolTimeCountCoroutine(MoneyCoolTime));
    }

    IEnumerator ResetSkillCoroutine() //��ų ��Ÿ��
    {
        while (CoolTime < 1)
        {
            CoolTime += 1 * Time.smoothDeltaTime / MoneyCoolTime;

            yield return null;
        }

        isUseSkill = true;
    }
    /*IEnumerator CoolTimeCountCoroutine(float number) //��ų ��Ÿ�� �ؽ�Ʈ ǥ��
    {
        if (number > 0)
        {
            number -= 1;

            MoneyCoolTimeText.text = number.ToString();

            yield return new WaitForSeconds(1f);
            StartCoroutine(CoolTimeCountCoroutine(number));
        }
        else
        {
            MoneyCoolTimeText.text = "Skill";
            MoneyFillAmout.fillAmount = 0;
            yield break;
        }
    }*/
}
