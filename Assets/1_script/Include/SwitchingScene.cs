using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchingScene : MonoBehaviour
{
    public string SceneToLoad;
 
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);            //���Ŵ����� Ȱ���Ͽ� ���� �ҷ���
    }
    public void Update() 
    { 
        
    }
}
