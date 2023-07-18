using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    public static BuffManager instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject BuffPreFab;

    public void CreateBuff(string type, float per, float du)//, Sprite icon)
    {
        GameObject go = Instantiate(BuffPreFab, transform);
        go.GetComponent<BaseBuff>().Init(type, per, du);
       // go.GetComponent<UnityEngine.UI.Image>().sprite = icon;
    }
}
