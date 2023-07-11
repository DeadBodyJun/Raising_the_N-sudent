using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTime : MonoBehaviour
{
    public Text TimeText;                                         
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.GameTime -= Time.deltaTime ;
        TimeText.text = "   D-day: " + (int)GameManager.instance.GameTime / 86400 + "¿œ";   

    }
}
