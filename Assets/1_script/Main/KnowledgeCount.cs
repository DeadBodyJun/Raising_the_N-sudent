using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KnowledgeCount : MonoBehaviour
{

    public Text Count;
    public GameObject Knowledge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Count.text = "Áö´É : " + GameManager.instance.Knolge;
    }
}
