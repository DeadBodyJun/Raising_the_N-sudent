using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)                            //터치를 실행할 경우
            {
                SceneManager.LoadScene(SceneToLoad);                                         //"메인" 씬을 불러옴
            }
        }
    }
}
