// �ٸ� ���� �������� �ð� �帣�� ��ũ��Ʈ
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
        GameManager.instance.GameTime -= Time.deltaTime*3600;                     // ���� ���� �ð��� ��ŸŸ���� ���ؼ� ��� ������Ŵ

    }

}
